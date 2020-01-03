using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Library
{
    public class DataReader : IDataReader
    {
        public List<string[]> ReadFile(string filePath, int delimeter)
        {
            var records = new List<string[]>();

            char separater;
            if (delimeter == (int)FileType.CSV)
            {
                separater = ',';
            }
            else
            {
                separater = '\t';
            }

            String[] lines = File.ReadAllLines(filePath).Skip(1).ToArray();

            records.AddRange(lines.Select(x => x.Split(separater)).ToList());

            return records;
        }
    }
}

