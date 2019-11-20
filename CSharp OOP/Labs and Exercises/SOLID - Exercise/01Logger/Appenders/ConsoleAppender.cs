﻿namespace _01Logger.Appenders
{
    using System;

    using Enums;
    using Layouts;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public void Append(string dateTime, LogLevel logLevel, string message)
        {
            Console.WriteLine(this.Layout.Format, dateTime, logLevel, message);
        }
    }
}
