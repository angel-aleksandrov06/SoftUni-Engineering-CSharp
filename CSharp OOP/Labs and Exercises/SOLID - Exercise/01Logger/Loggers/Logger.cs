namespace _01Logger.Loggers
{
    using System;

    using Appenders;
    using Enums;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get
            {
                return appenders;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders), "value cannot be null");
                }

                appenders = value;
            }
        }

        public void ERROR(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.ERROR, message);
        }

        public void INFO(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.INFO, message);
        }

        public void FATAL(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.FATAL, message);
        }

        public void CRITICAL(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.CRITICAL, message);
        }

        public void WARNING(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.WARNING, message);

        }

        private void Append(string dateTime, ReportLevel error, string message)
        {
            foreach (IAppender appender in Appenders)
            {
                appender.Append(dateTime, error, message);
            }
        }
    }
}
