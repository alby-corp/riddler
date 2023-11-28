using System.Text.Json;
using Bogus;
using Riddler.Puzzle2.Model;
using static System.Console;
using static System.Environment;
using static System.IO.File;

const string origin = "http://localhost:5000/";
const string extension = ".txt";
const int chunk = 6;

var flavors = new[] { "Hazelnut", "Chocolate", "Vanilla" };
var layers = new[] { 1, 2, 3 };
var shape = new[] { "Square", "Hearth", "Round" };

var faker = new Faker();

#region Builder

var cakes = new List<Cake>();
foreach (var _ in Enumerable.Range(1, chunk))
    cakes.Add(new()
    {
        Flavor = faker.PickRandom(flavors),
        Layers = faker.PickRandom(layers),
        Shape = faker.PickRandom(shape)
    });

#endregion

#region Decorator

foreach (var cake in cakes)
{
    var client = new HttpClient
    {
        BaseAddress = new(origin)
    };

    var request = new HttpRequestMessage(HttpMethod.Get, "cake/frosting");
    var response = client.Send(request);

    if (!response.IsSuccessStatusCode) WriteLine("Cannot read frosting: {0}", response.ReasonPhrase);

    using var stream = response.Content.ReadAsStream();
    using var reader = new StreamReader(stream);

    var frosting = reader.ReadToEnd();
    cake.Frosting = frosting;
}

#endregion

#region Birthday

const string jsonFilePath = "birthdayCakes.json";
var jsonString = ReadAllText(jsonFilePath);

var birthdayCakes = JsonSerializer.Deserialize<List<Cake>>(jsonString) ?? [];

#endregion

#region Catalog Builder

List<Cake> myCakes = [];
foreach (var cake in cakes)
{
    var isBirthday = false;
    foreach (var birthdayCake in birthdayCakes)
        if (cake.Flavor == birthdayCake.Flavor && cake.Shape == birthdayCake.Shape && cake.Frosting == birthdayCake.Frosting)
        {
            isBirthday = true;
            break;
        }

    Cake myCake = isBirthday
        ? new Cake.Birthday
        {
            Flavor = cake.Flavor,
            Frosting = cake.Frosting,
            Layers = cake.Layers,
            Shape = cake.Shape
        }
        : new Cake.AllDays
        {
            Flavor = cake.Flavor,
            Frosting = cake.Frosting,
            Layers = cake.Layers,
            Shape = cake.Shape
        };

    myCakes.Add(myCake);
}

#endregion

string? path;

do
{
    WriteLine("Please enter a valid path");
    path = ReadLine();
} while (string.IsNullOrEmpty(path) || path.Length < 3);

#region Writer

static void WriteCatalog(string path, string name, IEnumerable<Cake> cakes)
{
    if (!cakes.Any())
    {
        WriteLine("No {0} cakes in our catalogue!", name);
        return;
    }

    WriteAllLines(Path.Combine(path, $"{name} catalogue_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{extension}"), cakes.Select(cake => $"{cake}{NewLine}"));
}

WriteCatalog(path, "Birthday", myCakes.OfType<Cake.Birthday>());
WriteCatalog(path, "All days", myCakes.OfType<Cake.AllDays>());

#endregion

WriteLine("Done!");