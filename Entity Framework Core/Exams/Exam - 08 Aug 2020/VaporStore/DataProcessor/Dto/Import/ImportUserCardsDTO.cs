using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserCardsDTO
    {
        [Required]
        [RegularExpression(@"^([A-z][a-z]+) ([A-z][a-z]+)$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public ImportCardsDto[] Cards { get; set; }
    }
}
