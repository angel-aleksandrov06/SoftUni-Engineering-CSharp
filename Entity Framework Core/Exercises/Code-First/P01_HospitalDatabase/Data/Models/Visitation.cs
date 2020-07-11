﻿namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Visitation
    {
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
