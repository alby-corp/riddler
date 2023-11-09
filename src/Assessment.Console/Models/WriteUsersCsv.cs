using Assessment.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Console.Models
{
    internal class WriteUsersCsv
    {
        private readonly string _path;

        internal WriteUsersCsv(string path)
        {
            _path = path;
        }

        internal void WriteToFile(List<User> completeUsers)
        {            
            File.WriteAllLines(Path.Combine(_path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{Constant.extension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
        }

    }
}
