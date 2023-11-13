namespace Assessment.Console.Models;

using System.Collections.Generic;

public interface IReaderUsersCsv
{
    IEnumerable<Csv> ReaderFromFile(string path);
}

