namespace Assessment.Console.Exceptions
{
    internal class ResponseException : Exception
    {
        public ResponseException(string value) : base($"Response An error occured: [{value}]")
        {
        }

    }
}
