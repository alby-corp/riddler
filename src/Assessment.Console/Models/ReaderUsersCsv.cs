namespace Assessment.Console.Models
{
    internal class ReaderUsersCsv
    {
        private readonly string _path;

        internal ReaderUsersCsv(string path)
        {
            _path = path;
        }

        internal IEnumerable<Csv> ReaderFromFile()
        {             
            var lines = File.ReadAllLines(Path.Combine(_path, $"input{Constant.extension}"));
            var users = lines
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    var split = line.Split(Constant.separator);
                    return new Csv
                    (
                        givenName: split[0].Trim(),
                        familyName: split[1].Trim()
                    );
                });

            return users;
        }
    }
}
