namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ImportProducerDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^([A-Z][a-z]{2,}) ([A-Z][a-z]{2,})$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 (\d{3}) (\d{3}) (\d{3})$")]
        public string PhoneNumber { get; set; }

        public ImportProducerAlbumDTO[] Albums { get; set; }
    }
}
