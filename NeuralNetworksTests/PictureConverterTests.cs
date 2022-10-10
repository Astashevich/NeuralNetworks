using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace NeuralNetworks.Tests
{
    [TestClass()]
    public class PictureConverterTests
    {
        private const string TestFilesDirectoryName = "Images";

        public static string GetBaseSolutionFolderPath()
        {
            var directory = new DirectoryInfo(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty);
            while (directory != null && !directory.GetDirectories(TestFilesDirectoryName).Any())
            {
                directory = directory.Parent;
            }

            return directory.FullName;
        }

        public static string GetTestFilesPath()
        {
            return Path.Combine(GetBaseSolutionFolderPath(), TestFilesDirectoryName);
        }

        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new PictureConverter();
            var inputs = converter.Convert(Path.Combine(GetTestFilesPath(), "Parasitized.png"));
            converter.Save("d:\\image.png", inputs);
        }
    }
}