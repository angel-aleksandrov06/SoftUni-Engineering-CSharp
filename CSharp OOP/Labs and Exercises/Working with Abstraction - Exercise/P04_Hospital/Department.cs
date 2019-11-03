namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();

            CreateRooms();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public bool AddPatientToRoom(Patient patient)
        {
            var currentRoom = this.Rooms.FirstOrDefault(r => !r.IsFull);

            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var room in Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    stringBuilder.AppendLine(patient.Name);
                }
            }
            return stringBuilder.ToString().TrimEnd(); 
        }
    }
}
