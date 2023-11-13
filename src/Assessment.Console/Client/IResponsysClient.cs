namespace Assessment.Console.Client;

using Assessment.Console.Models;
using Assessment.Shared;

public interface IResponsysClient
{
    User? GetCompleteUser(Csv user);
}
