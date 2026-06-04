using NUnit.Framework;
using JobSearchPlatform.Models;
using JobSearchPlatform.Factories;

namespace JobSearchPlatform.Tests.VacancyTests.VacancyTests
{
    [TestFixture]
    public class VacancyCreatorTests
    {
        [Test]
        public void ITVacancyCreator_CreatesVacancyWithITType()
        {
            ITVacancyCreator creator = new ITVacancyCreator();

            Vacancy vacancy = creator.Create("C# Developer", "TechCorp", 120000);

            Assert.AreEqual("IT", vacancy.Type);
            Assert.AreEqual("C# Developer", vacancy.Title);
            Assert.AreEqual("TechCorp", vacancy.Company);
            Assert.AreEqual(120000, vacancy.Salary);
        }

        [Test]
        public void MarketingVacancyCreator_CreatesVacancyWithMarketingType()
        {
            MarketingVacancyCreator creator = new MarketingVacancyCreator();

            Vacancy vacancy = creator.Create("Marketing Manager", "AdAgency", 90000);

            Assert.AreEqual("Marketing", vacancy.Type);
            Assert.AreEqual("Marketing Manager", vacancy.Title);
            Assert.AreEqual("AdAgency", vacancy.Company);
            Assert.AreEqual(90000, vacancy.Salary);
        }

        [Test]
        public void SalesVacancyCreator_CreatesVacancyWithSalesType()
        {
            SalesVacancyCreator creator = new SalesVacancyCreator();

            Vacancy vacancy = creator.Create("Sales Representative", "BigStore", 80000);

            Assert.AreEqual("Sales", vacancy.Type);
            Assert.AreEqual("Sales Representative", vacancy.Title);
            Assert.AreEqual("BigStore", vacancy.Company);
            Assert.AreEqual(80000, vacancy.Salary);
        }
    }
}