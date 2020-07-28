﻿namespace PetStore.Models
{
    using PetStore.Models.Enumerations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public byte Age { get; set; }

        public bool IsSold { get; set; }

        public decimal Price { get; set; }

        [Required]
        [ForeignKey("Breed")]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
