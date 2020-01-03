using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class FileWriter
    {
        private readonly IDataWriter _writer;

        public FileWriter(IDataWriter writer)
        {
            _writer = writer;
        }

        public void WriteLine(string str)
        {
            _writer.WriteLine(str);
        }

        public void SaveLog(bool append, string filePath)
        {
            _writer.SaveLog(append, filePath);
        }

        public StringBuilder Write(string str)
        {
            _writer.Write(str);

            return _writer.WriteString;
        }

        public void SaveFile(StringBuilder sb, string filePath)
        {
            _writer.SaveFile(sb, filePath);
        }
    }
}
