namespace Assessment.Console.Models;

using Assessment.Shared;

public interface IRetrieverUserCsv
{
    User? Retriever(Csv user);
}

