﻿namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Hall")]
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
