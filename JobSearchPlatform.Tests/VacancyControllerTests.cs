using Moq;
using NUnit.Framework;
using JobSearchPlatform;
using System.Collections.Generic;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class VacancyControllerTests
    {
        private Mock<IVacancyRepository> _mockRepository;
        private Mock<IVacancyView> _mockView;
        private VacancyController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IVacancyRepository>();
            _mockView = new Mock<IVacancyView>();
            _controller = new VacancyController(_mockRepository.Object, _mockView.Object);
        }

        [Test]
        public void AddVacancy_ValidData_AddsToRepository()
        {
            _mockView.Setup(v => v.GetNewVacancyData()).Returns(("Разработчик", "TechCorp", 100000, "IT"));
            _mockView.Setup(v => v.ShowSuccess(It.IsAny<string>()));

            _controller.AddVacancy();

            _mockRepository.Verify(r => r.Add(It.IsAny<Vacancy>()), Times.Once);
            _mockView.Verify(v => v.ShowSuccess(It.Is<string>(s => s.Contains("добавлена"))), Times.Once);
        }

        [Test]
        public void DeleteVacancy_ValidId_DeletesFromRepository()
        {
            Vacancy testVacancy = new Vacancy { Id = 1, Title = "Тест" };
            _mockRepository.Setup(r => r.GetAll()).Returns(new List<Vacancy> { testVacancy });
            _mockView.Setup(v => v.GetIdForDelete()).Returns(1);
            _mockView.Setup(v => v.ShowSuccess(It.IsAny<string>()));

            _controller.DeleteVacancy();

            _mockRepository.Verify(r => r.Delete(1), Times.Once);
            _mockView.Verify(v => v.ShowSuccess(It.Is<string>(s => s.Contains("удалена"))), Times.Once);
        }

        [Test]
        public void DeleteVacancy_IdNotFound_ShowsError()
        {
            Vacancy testVacancy = new Vacancy { Id = 1, Title = "Тест" };
            _mockRepository.Setup(r => r.GetAll()).Returns(new List<Vacancy> { testVacancy });
            _mockView.Setup(v => v.GetIdForDelete()).Returns(999);

            _controller.DeleteVacancy();

            _mockRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Never);
            _mockView.Verify(v => v.ShowError(It.Is<string>(s => s.Contains("не найдена"))), Times.Once);
        }

        [Test]
        public void AddVacancy_InvalidType_ShowsError()
        {
            _mockView.Setup(v => v.GetNewVacancyData()).Returns(("Разработчик", "TechCorp", 100000, "Unknown"));

            _controller.AddVacancy();

            _mockRepository.Verify(r => r.Add(It.IsAny<Vacancy>()), Times.Never);
            _mockView.Verify(v => v.ShowError(It.Is<string>(s => s.Contains("Неизвестный тип"))), Times.Once);
        }
    }
}