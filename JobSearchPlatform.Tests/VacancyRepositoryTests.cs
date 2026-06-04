using NUnit.Framework;
using JobSearchPlatform;
using System.IO;
using System.Collections.Generic;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class VacancyRepositoryTests
    {
        private string testFilePath;
        private VacancyRepository repository;

        [SetUp]
        public void Setup()
        {
            testFilePath = "test_vacancies.txt";
            repository = new VacancyRepository(testFilePath);

            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void GetAll_WhenFileDoesNotExist_ReturnsEmptyList()
        {
            List<Vacancy> result = repository.GetAll();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Add_IncreasesCountByOne()
        {
            Vacancy vacancy = new Vacancy
            {
                Title = "Test",
                Company = "Test Corp",
                Salary = 1000,
                Type = "IT"
            };

            repository.Add(vacancy);
            List<Vacancy> all = repository.GetAll();

            Assert.AreEqual(1, all.Count);
            Assert.AreEqual("Test", all[0].Title);
            Assert.AreEqual(1000, all[0].Salary);
        }

        [Test]
        public void Add_AssignsIdAutomatically()
        {
            Vacancy first = new Vacancy { Title = "First", Company = "A", Salary = 1000, Type = "IT" };
            Vacancy second = new Vacancy { Title = "Second", Company = "B", Salary = 2000, Type = "Marketing" };

            repository.Add(first);
            repository.Add(second);

            List<Vacancy> all = repository.GetAll();

            Assert.AreEqual(1, all[0].Id);
            Assert.AreEqual(2, all[1].Id);
        }

        [Test]
        public void Delete_RemovesVacancyWithGivenId()
        {
            Vacancy vacancy = new Vacancy { Title = "ToDelete", Company = "X", Salary = 500, Type = "Sales" };
            repository.Add(vacancy);

            repository.Delete(vacancy.Id);
            List<Vacancy> all = repository.GetAll();

            Assert.AreEqual(0, all.Count);
        }

        [Test]
        public void Delete_DoesNothing_WhenIdDoesNotExist()
        {
            Vacancy vacancy = new Vacancy { Title = "Keep", Company = "X", Salary = 500, Type = "IT" };
            repository.Add(vacancy);

            repository.Delete(999);
            List<Vacancy> all = repository.GetAll();

            Assert.AreEqual(1, all.Count);
            Assert.AreEqual("Keep", all[0].Title);
        }

        [Test]
        public void GetAll_LoadsVacanciesFromFile()
        {
            Vacancy first = new Vacancy { Title = "First", Company = "A", Salary = 1000, Type = "IT" };
            Vacancy second = new Vacancy { Title = "Second", Company = "B", Salary = 2000, Type = "Marketing" };

            repository.Add(first);
            repository.Add(second);

            VacancyRepository newRepository = new VacancyRepository(testFilePath);
            List<Vacancy> loaded = newRepository.GetAll();

            Assert.AreEqual(2, loaded.Count);
            Assert.AreEqual("First", loaded[0].Title);
            Assert.AreEqual("Second", loaded[1].Title);
        }
    }
}