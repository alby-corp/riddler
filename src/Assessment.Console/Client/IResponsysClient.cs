namespace Assessment.Console.Client;

using Assessment.Console.Models;
using Assessment.Shared;

public interface IResponsysClient
{
    Task<User?> GetCompleteUser(Csv user);
}
