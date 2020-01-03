using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Library;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            int delimeter;
            string filePath;
            int fieldNumber;

            // ask user for file Path
            filePath = GetFilePath();

            if (File.Exists(filePath))
            {
                // ask user for file delimeter
                delimeter = GetDelimeter();  

                // ask user for the number of fields in each row
                fieldNumber = GetNumberOfFields();

                // Read file
                //var x = new DataReader();
                //var xxx = x.ReadFile(filePath, delimeter);

                Library.FileReader dataReader = new Library.FileReader(new DataReader());
                var records = dataReader.ReadFile(filePath, delimeter);

                ParseRecords(records, fieldNumber);              
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

            Environment.Exit(-1);
        }

        private static string GetFilePath()
        {
            Console.WriteLine("Enter file path.");
            string input = Console.ReadLine();
            return input;
        }

        private static int GetDelimeter()
        {
            int delimeter;
            bool parseInt;

            do 
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine()
                  .AppendFormat("Press {0} for {1} file.", (int)FileType.CSV, FileType.CSV)
                  .AppendLine()
                  .AppendFormat("Press {0} for {1} delimeted file.", (int)FileType.TSV, FileType.TSV);

                Console.WriteLine(sb);
                string input = Console.ReadLine();

                parseInt = int.TryParse(input, out delimeter);

            } while (parseInt && delimeter != (int)FileType.CSV && delimeter != (int)FileType.CSV);

            return delimeter;
        }

        private static int GetNumberOfFields()
        {
            string input;
            int fieldNumber;

            do
            {
                Console.WriteLine("Enter number of fields in each record.");
                input = Console.ReadLine();

            } while (int.TryParse(input, out fieldNumber) == false);

            return fieldNumber;
        }

        private static void ParseRecords(List<string[]> records, int fieldNumber)
        {
            FileWriter errorWriter = new FileWriter(new DataWriter());
            FileWriter fileWriter = new FileWriter(new DataWriter());

            StringBuilder errorRecords = new StringBuilder();
            StringBuilder fileRecords = new StringBuilder();

            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].Length == fieldNumber)
                {
                    //fileWriter.WriteLine(string.Join(",", records[i]));

                    fileRecords = fileWriter.Write(string.Join(",", records[i]));
                }
                else
                {
                    //errorWriter.WriteLine(string.Join(",", records[i]));
                    errorRecords = errorWriter.Write(string.Join(",", records[i]));
                }
            }

            //fileWriter.SaveLog(true, "C:\\temp\\success.csv");
            //errorWriter.SaveLog(true, "C:\\temp\\error.csv");

            fileWriter.SaveFile(fileRecords, "C:\\temp\\success.csv");
            errorWriter.SaveFile(errorRecords, "C:\\temp\\error.csv");
        }

    }
}
