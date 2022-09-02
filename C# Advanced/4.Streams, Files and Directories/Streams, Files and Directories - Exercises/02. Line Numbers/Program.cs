namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int index = 0;
            List<string> outputLines = new List<string>();

            foreach (var currentLine in lines)
            {
                index++;
                int countLetters = currentLine.Count(char.IsLetter);
                int punctuationMarks = currentLine.Count(char.IsPunctuation);
                string modifiedLines = $"Line {index}: {currentLine} ({countLetters})({punctuationMarks})";
                outputLines.Add(modifiedLines);
            }

            File.WriteAllLines(outputFilePath, outputLines);
        }
    }
}