using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeSalaryCommandTests
    {
        [Test]
        public void Execute_ChangesSalary()
        {
            Resume testResume = new Resume { Salary = 50000 };
            ChangeSalaryCommand changeSalaryCommand = new ChangeSalaryCommand(testResume, 100000);
            changeSalaryCommand.Execute();
            Assert.That(testResume.Salary, Is.EqualTo(100000));
        }

        [Test]
        public void Undo_RestoresOldSalary()
        {
            Resume testResume = new Resume { Salary = 50000 };
            ChangeSalaryCommand changeSalaryCommand = new ChangeSalaryCommand(testResume, 100000);
            changeSalaryCommand.Execute();
            changeSalaryCommand.Undo();
            Assert.That(testResume.Salary, Is.EqualTo(50000));
        }
    }
}