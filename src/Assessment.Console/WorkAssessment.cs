namespace Assessment.Console;

using Assessment.Console.Models;
using System;
using System.Threading.Tasks;
using static System.Console;

public class WorkAssessment
{
    private string? _path;

    private readonly IRetrieverUserCsv _retriever;
    private readonly IReaderUsersCsv _reader;
    private readonly IWriteUsersCsv _writer;

    public WorkAssessment(IReaderUsersCsv reader, IWriteUsersCsv writer, IRetrieverUserCsv retriever)
    {
        _retriever = retriever;
        _reader = reader;
        _writer = writer;
    }

    public Task StartWork()
    {
        while (true)
        try
        {
            Work();
        }
        catch (Exception e)
        {
            WriteLine("An error occurred: {0}", e.Message);
        }
    }

    private void Work()
    {
        _path = GetPath();

        #region Reader
        var csvUsers = _reader.ReaderFromFile(_path);
        #endregion

        #region Retriever        
        var completeUsers = csvUsers.Select(_retriever.Retriever).Where(c => c is not null);
        #endregion

        #region Writer
        WriteLine(_writer.WriteToFile(_path, completeUsers!));
        #endregion
    }

    private static string GetPath()
    {
        string? path;

        do
        {
            WriteLine("Please enter a valid path, for txt template");
            path = ReadLine();
        } while (string.IsNullOrEmpty(path) || path.Length < 3);

        return path;
    }
}









