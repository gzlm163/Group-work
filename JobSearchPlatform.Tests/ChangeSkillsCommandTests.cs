using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeSkillsCommandTests
    {
        [Test]
        public void Execute_ChangesSkills()
        {
            Resume resume = new Resume { Skills = "Старые" };
            ChangeSkillsCommand changeSkillsCommand = new ChangeSkillsCommand(resume, "Новые");
            changeSkillsCommand.Execute();
            Assert.That(resume.Skills, Is.EqualTo("Новые"));
        }

        [Test]
        public void Undo_RestoresOldSkills()
        {
            Resume resume = new Resume { Skills = "Старые" };
            ChangeSkillsCommand changeSkillsCommand = new ChangeSkillsCommand(resume, "Новые");
            changeSkillsCommand.Execute();
            changeSkillsCommand.Undo();
            Assert.That(resume.Skills, Is.EqualTo("Старые"));
        }
    }
}