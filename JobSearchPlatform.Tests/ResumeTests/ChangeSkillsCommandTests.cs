using JobSearchPlatform.Commands;
using JobSearchPlatform.Models;
using NUnit.Framework;

namespace JobSearchPlatform.Tests.ResumeTests
{
    [TestFixture]
    public class ChangeSkillsCommandTests
    {
        [Test]
        public void Execute_ChangesSkills()
        {
            Resume testResume = new Resume { Skills = "Старые" };
            ChangeSkillsCommand changeSkillsCommand = new ChangeSkillsCommand(testResume, "Новые");
            changeSkillsCommand.Execute();
            Assert.That(testResume.Skills, Is.EqualTo("Новые"));
        }

        [Test]
        public void Undo_RestoresOldSkills()
        {
            Resume testResume = new Resume { Skills = "Старые" };
            ChangeSkillsCommand changeSkillsCommand = new ChangeSkillsCommand(testResume, "Новые");
            changeSkillsCommand.Execute();
            changeSkillsCommand.Undo();
            Assert.That(testResume.Skills, Is.EqualTo("Старые"));
        }
    }
}