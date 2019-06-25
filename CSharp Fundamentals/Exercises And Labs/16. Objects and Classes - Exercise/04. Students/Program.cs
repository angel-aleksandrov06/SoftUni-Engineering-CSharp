using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentArgs = Console.ReadLine().Split(" ");

                string firstName = studentArgs[0];
                string lastName = studentArgs[1];
                double grade = double.Parse(studentArgs[2]);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            List<Student> sortedStudents = students.OrderByDescending(x=> x.Grade).ToList();

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:F2}";
        }
    }
}
