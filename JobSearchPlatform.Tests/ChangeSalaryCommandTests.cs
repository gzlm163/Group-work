using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeSalaryCommandTests
    {
        [Test]
        public void Execute_ChangesSalary()
        {
            Resume resume = new() { Salary = 50000 };
            ChangeSalaryCommand cmd = new(resume, 100000);
            cmd.Execute();
            Assert.That(resume.Salary, Is.EqualTo(100000));
        }

        [Test]
        public void Undo_RestoresOldSalary()
        {
            Resume resume = new() { Salary = 50000 };
            ChangeSalaryCommand cmd = new(resume, 100000);
            cmd.Execute();
            cmd.Undo();
            Assert.That(resume.Salary, Is.EqualTo(50000));
        }
    }
}