namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> occurences = new Dictionary<string, int>();

            string[] words = File.ReadAllText(wordsFilePath).Split();

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] wordsInCurrentLine = line.ToLower()
                    .Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        foreach (var item in wordsInCurrentLine)
                        {
                            if (word == item)
                            {
                                if (!occurences.ContainsKey(item))
                                {
                                    occurences.Add(item, 0);
                                }
                                occurences[item]++;
                            }
                        }
                    }


                    line = reader.ReadLine();
                }

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var occurence in occurences.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{occurence.Key} - {occurence.Value}");
                    }
                }
            }
        }
    }
}