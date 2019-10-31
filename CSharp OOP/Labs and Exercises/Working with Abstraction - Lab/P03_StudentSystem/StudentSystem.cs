using System;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private StudentsDatabase students;
        public StudentSystem()
        {
            this.students = new StudentsDatabase();
        }

        public void ParseCommands()
        {
            while (true)
            {
                string[] args = Console.ReadLine().Split();
                var commandName = args[0];
                if (commandName == "Create")
                {
                    this.Create(args);
                }
                else if (commandName == "Show")
                {
                    this.Show(args);
                }
                else if (commandName == "Exit")
                {
                    return;
                }
            }
        }

        private void Create(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            this.students.Add(name, age, grade);
        }

        private void Show(string[] args)
        {
            var name = args[1];
            var student = this.students.Find(name);
            if (student != null)
            {
                Console.WriteLine(student);
            }
        }
    }
}
