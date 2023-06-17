using FileStatusCheckerApplication.FileChecker;

namespace FileStatusCheckerApplication.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string forTest = "C:\\Users\\AiutJeKokot\\Desktop\\Repozytorium\\FileStatusChecker\\FileStatusCheckerApplication\\TempFiles";
            FileDirectionChecker checker = new FileDirectionChecker();
            var result = checker.GetListOfAllFilesInDirectiory(forTest);
            var dict = checker.GetFilesHashed(result);
        }
    }
}