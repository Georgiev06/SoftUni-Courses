namespace CopyDirectory
{
    using System;
    using System.IO;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] filePaths = Directory.GetFiles(inputPath);

            foreach (var filename in filePaths)
            {
                string fileName = filename.ToString();

                string copyDestination = Path.Combine(outputPath, fileName);

                if (!File.Exists(copyDestination ))
                {
                    File.Copy(fileName, copyDestination);
                }
            }
        }
    }
}

