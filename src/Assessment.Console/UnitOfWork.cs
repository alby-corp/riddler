namespace Assessment.Console;

using Assessment.Console.Abstract;
using static System.Console;

public class UnitOfWork
{
    private readonly IReader _reader;
    private readonly IRetriever _retriever;
    private readonly IWriter _writer;

    public UnitOfWork(IReader reader, IRetriever retriever, IWriter writer)
    {
        _reader = reader;
        _retriever = retriever;
        _writer = writer;
    }

    public async Task DoWork()
    {
        string? path;

        #region Validation

        do
        {
            WriteLine("Please enter a valid path, for txt template");
            path = ReadLine();
        } while (string.IsNullOrEmpty(path) || path.Length < 3);

        #endregion

        #region Reader

        var users = await _reader.ReadAsync(path);

        #endregion

        #region Retriever

        var completeUsers = _retriever.RetrieveAsync(users, WriteLine);

        #endregion

        #region Writer

        await _writer.WriteAsync(completeUsers, path, WriteLine);

        #endregion
    }
}
