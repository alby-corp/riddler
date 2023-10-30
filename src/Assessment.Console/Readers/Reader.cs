using Assessment.Console.Models;

namespace Assessment.Console.Readers
{
    public class Reader
    {
        string Path { get; }
        string Separator { get; }
        string Extension { get; }

        public Reader(string path, string separator, string extension) 
        { 
            Path = path;
            Separator = separator;
            Extension = extension;
        }

        public IEnumerable<Csv> Read() 
        {
            var lines = File.ReadAllLines(System.IO.Path.Combine(Path, $"input{Extension}"));
            return lines
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    var split = line.Split(Separator);
                    return new Csv(split[0].Trim(), split[1].Trim());
                });
        }
    }
}
