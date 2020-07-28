﻿namespace PetStore.Models
{
    using PetStore.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProduct>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.TownNameMinLength)]
        public string Town { get; set; }

        [Required]
        [MinLength(GlobalConstants.AddressTextMinLength)]
        public string Address { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

        public decimal TotalPrice => this.ClientProducts.Sum(x => x.Product.Price * x.Quantity);
    }
}
