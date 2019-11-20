namespace _01Logger.Loggers
{
    using Appenders;

    public interface ILogger
    {
        IAppender[] Appenders {get;}

        void Error(string dateTime, string message);

        void Info(string dateTime, string message);
    }
}
