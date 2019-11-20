namespace _01Logger.Loggers
{
    using Appenders;
    using Enums;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public void Error(string dateTime, string message)
        {
            foreach (IAppender appender in this.Appenders)
            {
                appender.Append(dateTime, LogLevel.Error, message);
            }
        }

        public void Info(string dateTime, string message)
        {
            foreach (IAppender appender in this.Appenders)
            {
                appender.Append(dateTime, LogLevel.Info, message);
            }
        }
    }
}
