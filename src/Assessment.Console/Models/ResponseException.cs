namespace Assessment.Console.Models
{
    internal class ResponseException : Exception
    {
        public ResponseException(string value) : base(string.Format("An error occured: [{0}]", value))
        {
        }

    }
}
