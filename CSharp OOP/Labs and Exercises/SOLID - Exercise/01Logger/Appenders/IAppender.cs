namespace _01Logger.Appenders
{
    using Layouts;

    public interface IAppender
    {
        public ILayout Layout { get; }
    }
}
