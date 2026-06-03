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
                Title = "Test",
                Company = "Test Corp",
                Salary = 1000,
                Type = "IT"
            };

            string result = vacancy.ToFileString();

            Assert.AreEqual("1|Test|Test Corp|1000|IT", result);
        }

        [Test]
        public void FromFileString_CreatesVacancyCorrectly()
        {
            string line = "1|Test|Test Corp|1000|IT";

            Vacancy vacancy = Vacancy.FromFileString(line);

            Assert.AreEqual(1, vacancy.Id);
            Assert.AreEqual("Test", vacancy.Title);
            Assert.AreEqual("Test Corp", vacancy.Company);
            Assert.AreEqual(1000, vacancy.Salary);
            Assert.AreEqual("IT", vacancy.Type);
        }
    }
}