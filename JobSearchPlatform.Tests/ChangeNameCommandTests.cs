namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeNameCommandTests
    {
        [Test]
        public void Execute_ChangesName()
        {
            Resume resume = new Resume { Name = "Старое" };
            ChangeNameCommand changeNameCommand = new ChangeNameCommand(resume, "Новое");

            changeNameCommand.Execute();

            Assert.That(resume.Name, Is.EqualTo("Новое"));
        }

        [Test]
        public void Undo_RestoresOldName()
        {
            Resume resume = new Resume { Name = "Старое" };
            ChangeNameCommand changeNameCommand = new ChangeNameCommand(resume, "Новое");
            changeNameCommand.Execute();

            changeNameCommand.Undo();

            Assert.That(resume.Name, Is.EqualTo("Старое"));
        }
    }
}