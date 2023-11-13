namespace Assessment.Console.Models;

using Assessment.Shared;

public interface IRetrieverUserCsv
{
    //  Task<User?> Retriever(Csv user);

    Task<IEnumerable<User>> Retriever(IEnumerable<Csv> csvUsers);

}

