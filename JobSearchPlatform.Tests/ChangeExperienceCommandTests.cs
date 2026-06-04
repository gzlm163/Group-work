using NUnit.Framework;

namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeExperienceCommandTests
    {
        [Test]
        public void Execute_ChangesExperience()
        {
            Resume resume = new Resume { Experience = 2 };
            ChangeExperienceCommand changeExperienceCommand = new ChangeExperienceCommand(resume, 5);
            changeExperienceCommand.Execute();
            Assert.That(resume.Experience, Is.EqualTo(5));
        }

        [Test]
        public void Undo_RestoresOldExperience()
        {
            Resume resume = new Resume { Experience = 2 };
            ChangeExperienceCommand changeExperienceCommand = new ChangeExperienceCommand(resume, 5);
            changeExperienceCommand.Execute();
            changeExperienceCommand.Undo();
            Assert.That(resume.Experience, Is.EqualTo(2));
        }
    }
}