using JobSearchPlatform.Models;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace JobSearchPlatform.Tests.ResumeTests
{
    [TestFixture]
    public class ResumeRepositoryTests
    {
        private const string TestFile = "resume.txt";
        private ResumeRepository _repository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(TestFile)) File.Delete(TestFile);
            _repository = new ResumeRepository();
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(TestFile)) File.Delete(TestFile);
        }

        [Test]
        public void Load_WhenFileMissing_ReturnsNull()
        {
            Resume result = _repository.Load();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Save_CreatesFileWithCorrectFormat()
        {
            Resume testResume = new Resume { Name = "Тест", Experience = 3, Skills = "C#", Salary = 100000 };
            _repository.Save(testResume);

            Assert.That(File.Exists(TestFile), Is.True);
            string fileContent = File.ReadAllText(TestFile, Encoding.UTF8);
            Assert.That(fileContent, Is.EqualTo("Тест|3|C#|100000"));
        }

        [Test]
        public void Load_WhenFileValid_ReturnsResume()
        {
            File.WriteAllText(TestFile, "Анна|2|Python|95000", Encoding.UTF8);

            Resume result = _repository.Load();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Анна"));
            Assert.That(result.Experience, Is.EqualTo(2));
            Assert.That(result.Skills, Is.EqualTo("Python"));
            Assert.That(result.Salary, Is.EqualTo(95000));
        }

        [Test]
        public void Load_WhenFileCorrupted_ReturnsNull()
        {
            File.WriteAllText(TestFile, "Анна|2|Python", Encoding.UTF8);
            Resume loadedResume = _repository.Load();
            Assert.That(loadedResume, Is.Null);
        }

        [Test]
        public void Load_WhenFileEmpty_ReturnsNull()
        {
            File.WriteAllText(TestFile, "", Encoding.UTF8);
            Resume result = _repository.Load();
            Assert.That(result, Is.Null);
        }
    }
}