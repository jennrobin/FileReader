using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Library
{
    public  class DataWriter :  IDataWriter
    {   
        private StringBuilder sb;
        public StringBuilder WriteString
        {
            get
            {
                if (sb == null)
                {
                    sb = new StringBuilder();
                }
                return sb;
            }
        }
        
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
            WriteString.Append(str).Append(Environment.NewLine);
        }

        public void SaveLog(bool append = false, string path = "./Log.txt")
        {
            if (WriteString != null && WriteString.Length > 0)
            {
                if (append)
                {
                    using (StreamWriter file = File.AppendText(path))
                    {
                        file.Write(WriteString.ToString());
                        file.Close();
                        file.Dispose();
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(path))
                    {
                        file.Write(WriteString.ToString());
                        file.Close();
                        file.Dispose();
                    }
                }
            }
        }


        public StringBuilder Write(string str)
        {
            WriteString.Append(str).Append(Environment.NewLine);

            return WriteString;
        }


        public void SaveFile(StringBuilder sb, string path = "./Log.txt")
        {
            if (sb != null && sb.Length > 0)
            {
                using (StreamWriter file = new StreamWriter(path))
                {
                    file.Write(WriteString.ToString());
                    file.Close();
                    file.Dispose();
                }

                Console.WriteLine(string.Format("{0} file created.", path));
            }
        }
    }
}
