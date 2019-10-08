using System;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            var picFolderPath = ".";
            var targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/rezylt.zip";

            ZipFile.CreateFromDirectory(picFolderPath, targetPath);

            ZipFile.ExtractToDirectory(targetPath, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}
