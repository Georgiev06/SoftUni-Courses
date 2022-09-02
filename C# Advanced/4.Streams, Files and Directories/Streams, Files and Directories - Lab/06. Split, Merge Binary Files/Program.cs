namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            long size1 = 0;
            long size2 = 0;

            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream writer1 = new FileStream(partOneFilePath, FileMode.CreateNew))
                {
                    using (FileStream writer2 = new FileStream(partTwoFilePath, FileMode.CreateNew))
                    {
                        size1 = reader.Length / 2;
                        size2 = reader.Length - size1;

                        if (size2 > size1)
                        {
                            long temp = size1;
                            size1 = size2;
                            size2 = temp;
                        }

                        byte[] buff1 = new byte[size1];

                        reader.Read(buff1, 0, buff1.Length);

                        writer1.Write(buff1, 0, buff1.Length);

                        byte[] buff2 = new byte[size2];

                        reader.Read(buff2, 0, buff2.Length);

                        writer2.Write(buff2, 0, buff2.Length);
                    }
                }
            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writer = new FileStream(joinedFilePath, FileMode.CreateNew))
            {
                using (FileStream reader = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buff = new byte[reader.Length];

                    reader.Read(buff, 0, buff.Length);
                    writer.Write(buff, 0, buff.Length);
                    using (FileStream reader1 = new FileStream(partTwoFilePath, FileMode.Open))
                    {
                        byte[] buff1 = new byte[reader1.Length];

                        reader1.Read(buff1, 0, buff1.Length);
                        writer.Write(buff1, 0, buff1.Length);
                    }
                }
            }
        }
    }
}
