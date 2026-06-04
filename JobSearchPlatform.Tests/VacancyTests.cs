using NUnit.Framework;
using JobSearchPlatform;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class VacancyTests
    {
        [Test]
        public void ToFileString_ReturnsCorrectFormat()
        {
            Vacancy vacancy = new Vacancy
            {
                Id = 1,
                Title = "C# Developer",
                Company = "TechCorp",
                Salary = 120000,
                Type = "IT"
            };

            string result = vacancy.ToFileString();

            Assert.AreEqual("1|C# Developer|TechCorp|120000|IT", result);
        }

        [Test]
        public void FromFileString_CreatesVacancyCorrectly()
        {
            string line = "1|C# Developer|TechCorp|120000|IT";

            Vacancy vacancy = Vacancy.FromFileString(line);

            Assert.AreEqual(1, vacancy.Id);
            Assert.AreEqual("C# Developer", vacancy.Title);
            Assert.AreEqual("TechCorp", vacancy.Company);
            Assert.AreEqual(120000, vacancy.Salary);
            Assert.AreEqual("IT", vacancy.Type);
        }
    }
}   