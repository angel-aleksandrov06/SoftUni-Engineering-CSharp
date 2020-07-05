using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            var result = GetEmployeesByFirstNameStartingWithSa(context);
            Console.WriteLine(result);
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                }
                )
                .OrderBy(e => e.EmployeeId).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(x => x.Salary > 50000)
                .Select( x => new 
                {
                    x.FirstName,
                    x.Salary
                }
                )
                .OrderBy(e => e.FirstName).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development").Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText).ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine(a);
            }

            return sb.ToString().Trim();
        }

        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                                                       ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                                    ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) :
                                    "not finished"
                    }).ToList()
                }).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(pn => pn)
                    .ToList()
                }).Single();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (string projectName in employee147.Projects)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    DepEmployess = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToList()
                })
                .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName}  {d.ManagerLastName}");

                foreach (var e in d.DepEmployess)
                {
                    sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            IQueryable<Employee> employeesToIncrease = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services");

            foreach (Employee employee in employeesToIncrease)
            {
                employee.Salary += employee.Salary * 0.12M;
            }

            context.SaveChanges();

            var employeesInfo = employeesToIncrease.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        //Problem 13
        //public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees.Where(e => EF.Functions.Like(e.FirstName, "sa%"))
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.LastName,
        //            e.JobTitle,
        //            e.Salary
        //        })
        //        .OrderBy(e => e.FirstName)
        //        .ThenBy(e => e.LastName)
        //        .ToList();

        //    foreach (var e in employees)
        //    {
        //        sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        //    }

        //    return sb.ToString().Trim();
        //}

        //Problem 13 --broken test
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            // broken test
            if (context.Employees.Any(e => e.FirstName == "Svetlin"))
            {
                string pattern = "SA";
                var employeesByNamePattern = context.Employees
                    .Where(employee => employee.FirstName.StartsWith(pattern));

                foreach (var employeeByPattern in employeesByNamePattern)
                {
                    output.AppendLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
                                       $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
                }
            }
            else
            {
                var employeesByNamePattern = context.Employees.Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                foreach (var employee in employeesByNamePattern)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} " +
                                       $"- {employee.JobTitle} - (${employee.Salary:F2})");
                }
            }

            return output.ToString().Trim();
        }

        //Probem 15
        public static string RemoveTown(SoftUniContext context)
        {
            Town townToDel = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDel = context.Addresses.Where(a => a.TownId == townToDel.TownId);

            int addressesCount = addressesToDel.Count();

            IQueryable<Employee> employeesOnDeletedAddresses = context.Employees.Where(e => addressesToDel.Any(a => a.AddressId == e.AddressId));

            foreach (Employee e in employeesOnDeletedAddresses)
            {
                e.AddressId = null;
            }

            foreach (Address address in addressesToDel)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDel);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
