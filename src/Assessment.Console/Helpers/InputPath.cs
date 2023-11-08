using static System.Console;
namespace Assessment.Console.Helpers
{
    public static class InputPath
    {
        public static string GetValidPath()
        {
            string? path;
            do
            {
                WriteLine("Please enter a valid path for the txt template:");
                path = ReadLine();
            } while (string.IsNullOrEmpty(path) || path.Length < 3);

            return path;
        }
    }
}
