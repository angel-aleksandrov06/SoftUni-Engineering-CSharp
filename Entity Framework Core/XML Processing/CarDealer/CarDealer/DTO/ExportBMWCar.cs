namespace CarDealer.DTO
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportBMWCar
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
