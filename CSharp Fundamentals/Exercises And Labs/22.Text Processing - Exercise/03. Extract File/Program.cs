using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(@"\").Reverse().ToArray();

            var FilenameAndExtension = input[0].Split(".");

            var fileName = FilenameAndExtension[0];
            var extesion = FilenameAndExtension[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extesion}");
        }
    }
}
