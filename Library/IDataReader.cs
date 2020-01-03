using System.Collections.Generic;


namespace Library
{
    public interface IDataReader
    {
        List<string[]> ReadFile(string filePath, int delimeter);
    }
}
