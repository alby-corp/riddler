using Assessment.Console.Abstract;
using static System.Console;

namespace Assessment.Console
{
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

        public void DoWork(string separator, string extension)
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

            var users = _reader.Read(path, separator, extension);

            #endregion

            #region Retriever

            var completeUsers = _retriever.Retrieve(users, WriteLine);

            #endregion

            #region Writer

            if (completeUsers.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }

            _writer.Write(completeUsers, path, extension, WriteLine);

            #endregion
        }
    }
}
