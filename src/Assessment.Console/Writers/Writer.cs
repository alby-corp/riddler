using Assessment.Shared;
using static System.Console;

namespace Assessment.Console.Writers
{
    public class Writer
    {
        List<User> CompleteUsers { get; }
        string FilePath { get; }
        string Extension { get; }

        public Writer(List<User> completeUsers, string path, string extension) 
        {
            CompleteUsers = completeUsers;
            FilePath = path;
            Extension = extension;
        }

        public void Write() 
        {
            File.WriteAllLines(Path.Combine(FilePath, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{Extension}"), CompleteUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
            WriteLine("Done!");
        }
    }
}
