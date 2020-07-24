﻿namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
