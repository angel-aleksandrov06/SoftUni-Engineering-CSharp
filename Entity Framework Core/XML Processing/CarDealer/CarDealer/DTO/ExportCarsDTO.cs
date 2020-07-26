namespace CarDealer.DTO
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TraveledDistance { get; set; }

    }
}
