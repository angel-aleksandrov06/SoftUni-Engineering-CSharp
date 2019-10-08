using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("..\\..\\..\\");

            var dict = new Dictionary<string, Dictionary<string, long>>();

            var files = di.GetFiles();

            foreach (var file in files)
            {
                var extension = file.Extension;

                if (!dict.ContainsKey(extension))
                {
                    dict.Add(extension, new Dictionary<string, long>());
                }

                dict[extension].Add(file.Name, file.Length);
            }

            var sortedDict = dict.OrderByDescending(e => e.Value.Count)
                .ThenBy(е => е.Key)
                .ToDictionary(x => x.Key, x => x.Value);



            using (var streamWriter = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt"), false))
            {
                foreach (var extension in sortedDict)
                {
                    streamWriter.WriteLine(extension.Key);

                    var currentFiles = extension.Value
                        .OrderBy(f => f.Value)
                        .ToDictionary(x => x.Key, y => y.Value);

                    foreach (var file in currentFiles)
                    {
                        streamWriter.WriteLine($"--{file.Key} - {(file.Value / 1000.0):F3}kb");
                    }
                }
            }
        }
    }
}
