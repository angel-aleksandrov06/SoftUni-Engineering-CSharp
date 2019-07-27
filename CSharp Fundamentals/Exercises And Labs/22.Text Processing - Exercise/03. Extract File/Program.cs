using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int indexOfLastSlash = path.LastIndexOf(@"\");
            int fileNameLenght = path.Length - (indexOfLastSlash+1);

            string currentFile = path.Substring(indexOfLastSlash+1, fileNameLenght);

            string[] fileName = currentFile.Split(".");

            Console.WriteLine($"File name: {fileName[0]}");
            Console.WriteLine($"File extension: {fileName[1]}");
        }
    }
}
