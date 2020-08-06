namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ImportWriterDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [RegularExpression(@"^([A-Z][a-z]{2,}) ([A-Z][a-z]{2,})$")]
        public string Pseudonym { get; set; }
    }
}
