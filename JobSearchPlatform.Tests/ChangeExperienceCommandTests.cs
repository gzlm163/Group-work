using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeExperienceCommandTests
    {
        [Test]
        public void Execute_ChangesExperience()
        {
            Resume resume = new() { Experience = 2 };
            ChangeExperienceCommand cmd = new(resume, 5);
            cmd.Execute();
            Assert.That(resume.Experience, Is.EqualTo(5));
        }

        [Test]
        public void Undo_RestoresOldExperience()
        {
            Resume resume = new Resume { Experience = 2 };
            ChangeExperienceCommand cmd = new(resume, 5);
            cmd.Execute();
            cmd.Undo();
            Assert.That(resume.Experience, Is.EqualTo(2));
        }
    }
}