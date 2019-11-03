namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }
        public List<Patient> Patients { get; set; }

        public bool IsFull => this.Patients.Count >= 3;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var patient in Patients.OrderBy(p=>p.Name))
            {
                stringBuilder.AppendLine(patient.Name);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
