using Assessment.API;
using Assessment.Shared;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();


var api = app.MapGroup("/users");

api.MapGet("/", ([FromQuery(Name = "given-name")] string givenName, [FromQuery(Name = "family-name")] string familyName) =>
{
    if (string.IsNullOrEmpty(givenName) || string.IsNullOrEmpty(familyName)) return Results.BadRequest("Invalid parameters!");

    var random = new Random();
    return random.Next(1, 100) > 90
        ? Results.NotFound()
        : Results.Ok(new User
        {
            GivenName = givenName.FirstCharToUpper(),
            FamilyName = familyName.FirstCharToUpper(),
            Email = $"{givenName}.{familyName}@euris.it"
        });
});

await app.RunAsync();