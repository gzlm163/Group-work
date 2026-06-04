using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeSalaryCommandTests
    {
        [Test]
        public void Execute_ChangesSalary()
        {
            Resume resume = new Resume { Salary = 50000 };
            ChangeSalaryCommand changeSalaryCommand = new ChangeSalaryCommand(resume, 100000);
            changeSalaryCommand.Execute();
            Assert.That(resume.Salary, Is.EqualTo(100000));
        }

        [Test]
        public void Undo_RestoresOldSalary()
        {
            Resume resume = new Resume { Salary = 50000 };
            ChangeSalaryCommand changeSalaryCommand = new ChangeSalaryCommand(resume, 100000);
            changeSalaryCommand.Execute();
            changeSalaryCommand.Undo();
            Assert.That(resume.Salary, Is.EqualTo(50000));
        }
    }
}