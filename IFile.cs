using System;

public interface IFile
{
	string FileName { get; set; }
    string Directory { get; set; }

    bool ReadFile(string fileName);
    void WriteFile(Customer customer);
}
