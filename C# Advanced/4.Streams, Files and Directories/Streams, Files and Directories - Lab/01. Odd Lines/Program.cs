namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int index = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (index % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    index++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}