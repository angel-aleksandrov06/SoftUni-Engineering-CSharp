namespace CarDealer.DTO
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarPartDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportPartDTO[] Parts { get; set; }
    }

    [XmlType("part")]
    public class ExportPartDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
