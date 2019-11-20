namespace _01Logger.Appenders
{
    using Enums;
    using Layouts;
    using Loggers;

    public class FileAppender : IAppender
    {
        private ILogFile LogFile;
        public FileAppender(ILayout layout, ILogFile logfile)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public void Append(string dateTime, LogLevel logLevel, string message)
        {
            this.LogFile.Write(string.Format(this.Layout.Format, dateTime, logLevel, message));
        }
    }
}
