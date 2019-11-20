namespace _01Logger.Loggers
{
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message);
        }

        public int Size => File.ReadAllText(LogFilePath).Where(char.IsLetter).Sum(c => c);
    }
}
