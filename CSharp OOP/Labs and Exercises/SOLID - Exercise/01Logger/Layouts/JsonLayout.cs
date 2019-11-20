namespace _01Logger.Layouts
{
    public class JsonLayout : ILayout
    {

        public string Format => @"{{
      ""log"": {{
        ""date"": {0},
        ""level"": {1},
        ""message"": {2}
    }}
}}";
    }
}
