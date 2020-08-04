﻿namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})\-(\d{3})\-(\d{4})$")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}
