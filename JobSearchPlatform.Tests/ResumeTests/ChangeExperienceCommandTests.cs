using JobSearchPlatform.Models;
using NUnit.Framework;

namespace JobSearchPlatform.Tests.ResumeTests
{
    [TestFixture]
    public class ChangeExperienceCommandTests
    {
        [Test]
        public void Execute_ChangesExperience()
        {
            Resume testResume = new Resume { Experience = 2 };
            ChangeExperienceCommand changeExperienceCommand = new ChangeExperienceCommand(testResume, 5);
            changeExperienceCommand.Execute();
            Assert.That(testResume.Experience, Is.EqualTo(5));
        }

        [Test]
        public void Undo_RestoresOldExperience()
        {
            Resume testResume = new Resume { Experience = 2 };
            ChangeExperienceCommand changeExperienceCommand = new ChangeExperienceCommand(testResume, 5);
            changeExperienceCommand.Execute();
            changeExperienceCommand.Undo();
            Assert.That(testResume.Experience, Is.EqualTo(2));
        }
    }
}