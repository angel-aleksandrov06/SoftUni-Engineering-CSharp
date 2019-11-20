namespace _01Logger.Appenders
{
    using System;

    using Enums;
    using Layouts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                Counter++;
                Console.WriteLine(Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
