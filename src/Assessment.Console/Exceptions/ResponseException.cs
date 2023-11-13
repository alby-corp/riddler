namespace Assessment.Console.Exceptions
{
    internal class ResponseException : Exception
    {
        public ResponseException(string value) : base($"An error occured: [{value}]")
        {
        }

    }
}
