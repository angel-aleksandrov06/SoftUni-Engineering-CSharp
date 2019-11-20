namespace _01Logger.Appenders
{
    using Enums;
    using Layouts;

    public interface IAppender
    {
        public ILayout Layout { get; }

        void Append(string dateTime, LogLevel logLevel, string message);
    }
}
