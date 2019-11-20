namespace _01Logger.Appenders
{
    using Enums;
    using Layouts;
    using Loggers;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logfile)
        : base(layout)
        {
            LogFile = logfile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                Counter++;
                LogFile.Write(string.Format(Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {LogFile.Size}";
        }
    }
}
