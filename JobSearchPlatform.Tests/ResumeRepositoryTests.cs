using NUnit.Framework;
using System.IO;
using System.Text;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ResumeRepositoryTests
    {
        private const string TestFile = "resume.txt";
        private ResumeRepository _repo;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(TestFile)) File.Delete(TestFile);
            _repo = new ResumeRepository();
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(TestFile)) File.Delete(TestFile);
        }

        [Test]
        public void Load_WhenFileMissing_ReturnsNull()
        {
            Resume result = _repo.Load();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Save_CreatesFileWithCorrectFormat()
        {
            Resume resume = new Resume { Name = "Тест", Experience = 3, Skills = "C#", Salary = 100000 };
            _repo.Save(resume);

            Assert.That(File.Exists(TestFile), Is.True);
            string content = File.ReadAllText(TestFile, Encoding.UTF8);
            Assert.That(content, Is.EqualTo("Тест|3|C#|100000"));
        }

        [Test]
        public void Load_WhenFileValid_ReturnsResume()
        {
            File.WriteAllText(TestFile, "Анна|2|Python|95000", Encoding.UTF8);

            Resume result = _repo.Load();

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
            Resume result = _repo.Load();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Load_WhenFileEmpty_ReturnsNull()
        {
            File.WriteAllText(TestFile, "", Encoding.UTF8);
            Resume result = _repo.Load();
            Assert.That(result, Is.Null);
        }
    }
}