namespace Assessment.Console.Models;

using Assessment.Console.Client;
using Assessment.Console.Exceptions;
using Assessment.Shared;
using static System.Console;

public class RetrieverUserCsv : IRetrieverUserCsv
{
    private readonly IResponsysClient _client;

    public RetrieverUserCsv(IResponsysClient client) => _client = client;
  
    public User? Retriever(Csv user)
    {
        try
        {
            return _client.GetCompleteUser(user);
        }
        catch (ResponseException e)
        {
            WriteLine(e.Message);
            return null;
        }
    }
}