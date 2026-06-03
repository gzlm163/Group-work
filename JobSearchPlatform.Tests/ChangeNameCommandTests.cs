namespace JobSearchPlatform.Tests
{
    [TestFixture]
    public class ChangeNameCommandTests
    {
        [Test]
        public void Execute_ChangesName()
        {
            Resume resume = new() { Name = "Старое" };
            ChangeNameCommand cmd = new(resume, "Новое");

            cmd.Execute();

            Assert.That(resume.Name, Is.EqualTo("Новое"));
        }

        [Test]
        public void Undo_RestoresOldName()
        {
            Resume resume = new() { Name = "Старое" };
            ChangeNameCommand cmd = new(resume, "Новое");
            cmd.Execute();

            cmd.Undo();

            Assert.That(resume.Name, Is.EqualTo("Старое"));
        }
    }
}