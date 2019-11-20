namespace _01Logger.Loggers
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
