using Assessment.Shared;
using static System.Console;

namespace Assessment.Console.Writers
{
    internal class Writer
    {
        const string extension = ".txt";

        readonly List<User> _completeUsers;
        readonly string _path;

        public Writer(List<User> completeUsers, string path)
        {
            _completeUsers = completeUsers;
            _path = path;
        } 

        public void Write()
        {
            if (_completeUsers.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }

            File.WriteAllLines(Path.Combine(_path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{extension}"), _completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
        }
    }
}