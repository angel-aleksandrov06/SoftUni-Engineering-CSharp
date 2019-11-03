using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] argumnets = command.Split();
                var departament = argumnets[0];
                var FirstNameOfDoctor = argumnets[1];
                var secondNameOfDoctor = argumnets[2];
                var patient = argumnets[3];
                var FullNameOfDoctor = FirstNameOfDoctor + " " + secondNameOfDoctor;

                this.hospital.AddDoctor(FirstNameOfDoctor, secondNameOfDoctor);
                this.hospital.AddDepartment(departament);
                this.hospital.AddPatient(departament, FullNameOfDoctor, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    var departmentName = args[0];
                    var department = this.hospital.Departments.FirstOrDefault(de => de.Name == departmentName);
                    Console.WriteLine(department.ToString());
                }
                else
                {
                    var isRoom = int.TryParse(args[1], out int resultRoom);


                    if (isRoom)
                    {
                        var departmentName = args[0];
                        var department = this.hospital.Departments.FirstOrDefault(de => de.Name == departmentName);

                        var currentRoom = department.Rooms[resultRoom - 1];
                        Console.WriteLine(currentRoom);
                    }
                    else
                    {
                        var firstName = args[0];
                        var secondName = args[1];

                        var fullName = firstName + " " + secondName;
                        var doctor = this.hospital.Doctors.FirstOrDefault(d => d.FullName == fullName);

                        Console.WriteLine(doctor);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
