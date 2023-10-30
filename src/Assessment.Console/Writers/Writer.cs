using Assessment.Console.Abstract;
using Assessment.Shared;
using static System.Console;

namespace Assessment.Console.Writers
{
    public class Writer : IWriter
    {
        public void Write(List<User> completeUsers, string path, string extension, Action<string>? console = default) 
        {
            File.WriteAllLines(Path.Combine(path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{extension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
            console?.Invoke("Done!");
        }
    }
}
