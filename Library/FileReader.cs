using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class FileReader
    {
        private readonly IDataReader _reader;


        public FileReader(IDataReader dataReader)
        {
            this._reader = dataReader;
        }

        public List<string[]> ReadFile(string filePath, int delimeter)
        {
           return _reader.ReadFile(filePath, delimeter);
        }
    }
}
