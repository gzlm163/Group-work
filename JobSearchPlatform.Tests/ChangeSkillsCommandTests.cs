using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeSkillsCommandTests
    {
        [Test]
        public void Execute_ChangesSkills()
        {
            Resume resume = new() { Skills = "Старые" };
            ChangeSkillsCommand cmd = new(resume, "Новые");
            cmd.Execute();
            Assert.That(resume.Skills, Is.EqualTo("Новые"));
        }

        [Test]
        public void Undo_RestoresOldSkills()
        {
            Resume resume = new() { Skills = "Старые" };
            ChangeSkillsCommand cmd = new(resume, "Новые");
            cmd.Execute();
            cmd.Undo();
            Assert.That(resume.Skills, Is.EqualTo("Старые"));
        }
    }
}