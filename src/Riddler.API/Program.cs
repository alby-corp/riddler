using Bogus;
using Microsoft.AspNetCore.Mvc;
using Riddler.API;
using Riddler.Shared.Users;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();
var api = app.MapGroup("/");

api.MapGet("/users", ([FromQuery(Name = "given-name")] string givenName, [FromQuery(Name = "family-name")] string familyName) =>
{
    if (string.IsNullOrEmpty(givenName) || string.IsNullOrEmpty(familyName)) return Results.BadRequest("Invalid parameters!");

    var random = new Random();
    return random.Next(1, 100) > 90
        ? Results.NotFound()
        : Results.Ok(new User
        {
            GivenName = givenName.FirstCharToUpper(),
            FamilyName = familyName.FirstCharToUpper(),
            Email = $"{givenName}.{familyName}@mail.it"
        });
});

var faker = new Faker();
var frostings = new[] { "Buttercream", "Ganache", "Meringue" };

api.MapGet("/cake/frostings", () => frostings);
api.MapGet("/cake/frosting", () => faker.PickRandom(frostings));

await app.RunAsync();