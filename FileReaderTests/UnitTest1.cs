using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Abstractions.TestingHelpers;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FileIsNotEmpty()
        {
            var mockFileSystem = new MockFileSystem();

            var mockInputFile = new MockFileData("data1,data2,data3\ndata11,data22,data33\ndata111,data222,data333");

            mockFileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            Library.FileReader sut = new FileReader(new DataReader());
            var records = sut.ReadFile(mockFileSystem.Path.ToString(), 1);


            var fakeReader = new data();
            var path = "pathToSomeFile"
    var data = new[] { "Line 1", "Line 2", Line 3" };
    fakeReader.Files.Add(path, data)

    ProcessDataFromFile(path, fakeReader);

            Assert.IsNotNull(records);
        }
    }
}
