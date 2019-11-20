namespace _01Logger.Loggers
{
    using Appenders;

    public interface ILogger
    {
        IAppender[] Appenders {get;}

        void ERROR(string dateTime, string message);

        void INFO(string dateTime, string message);

        void FATAL(string dateTime, string message);

        void CRITICAL(string dateTime, string message);

        void WARNING(string dateTime, string message);
    }
}
