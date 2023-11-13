namespace Assessment.Console.Models;

using System.Collections.Generic;

public interface IReaderUsersCsv
{
   Task<IEnumerable<Csv>> ReaderFromFile(string path);
}

