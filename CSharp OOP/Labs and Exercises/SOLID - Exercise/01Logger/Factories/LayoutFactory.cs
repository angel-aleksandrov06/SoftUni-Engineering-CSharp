namespace _01Logger.Factories
{
    using System;
    using Layouts;

    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            switch (type.ToLower())
            {
                case "simplelayout":
                    return  new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                case "jsonlayout":
                    return new JsonLayout();
                default:
                    throw new ArgumentException("Invalid Layout!");
            }
        }
    }
}
