namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XMLHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray()
                .Where(x => x.Tasks.Count > 0)
                .Select(x => new ExportProjectWithTheirTasksDTO()
                {
                    Name = x.Name,
                    TasksCount = x.Tasks.Count,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.Select(z => new ExportTaskDTO()
                    {
                        Name = z.Name,
                        LabelType = z.LabelType.ToString(),
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.Name)
                .ToArray();

            var xml = XmlConverter.Serialize(projects, "Projects");

            return xml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .ToArray()
                .Where(x => x.EmployeesTasks.Count(z => z.Task.OpenDate >= date) > 0)
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(x => x.Task.OpenDate >= date) // !!!!!
                    .OrderByDescending(x => x.Task.DueDate)
                    .ThenBy(x => x.Task.Name)
                    .Select(et => new
                    {
                        TaskName = et.Task.Name,
                        OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = et.Task.LabelType.ToString(),
                        ExecutionType = et.Task.ExecutionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return json;
        }
    }
}