using Assessment.Console.Abstract;
using Assessment.Shared;
using static System.Console;

namespace Assessment.Console.Writers
{
    internal class Writer : IWriter
    {
        const string extension = ".txt";

        public void Write(List<User> completeUsers, string path)
        {
            if (completeUsers.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }

            File.WriteAllLines(Path.Combine(path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{extension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
        }
    }
}