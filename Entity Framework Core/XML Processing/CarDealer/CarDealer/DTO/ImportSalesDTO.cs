namespace CarDealer.DTO
{
    using System.Xml.Serialization;

    [XmlType("Sale")]
    public class ImportSalesDTO
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }
    }
}
