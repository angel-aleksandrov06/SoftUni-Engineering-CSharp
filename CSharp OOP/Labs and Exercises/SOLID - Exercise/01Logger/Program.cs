namespace _01Logger
{
    using System;
    using Appenders;
    using Layouts;

    class Program
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            Console.WriteLine(simpleLayout.Format, "test", "test", "test");
            

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

        }
    }
}
