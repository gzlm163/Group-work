using JobSearchPlatform.Commands;
using JobSearchPlatform.Models;

namespace JobSearchPlatform.Tests.ResumeTests
{
    [TestFixture]
    public class ChangeNameCommandTests
    {
        [Test]
        public void Execute_ChangesName()
        {
            Resume testResume = new Resume { Name = "Старое" };
            ChangeNameCommand changeNameCommand = new ChangeNameCommand(testResume, "Новое");

            changeNameCommand.Execute();

            Assert.That(testResume.Name, Is.EqualTo("Новое"));
        }

        [Test]
        public void Undo_RestoresOldName()
        {
            Resume testResume = new Resume { Name = "Старое" };
            ChangeNameCommand changeNameCommand = new ChangeNameCommand(testResume, "Новое");
            changeNameCommand.Execute();

            changeNameCommand.Undo();

            Assert.That(testResume.Name, Is.EqualTo("Старое"));
        }
    }
}