using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IDataWriter
    {
        StringBuilder WriteString { get; }

        void WriteLine(string str);

        void SaveLog(bool append = false, string filePath = "./Log.txt");

        StringBuilder Write(string str);

        void SaveFile(StringBuilder sb, string filePath = "./Log.txt");
    }
}
