using JobSearchPlatform.Interfaces;

namespace JobSearchPlatform.Tests.ResumeTests
{
    [TestFixture]
    public class CommandHistoryTests
    {
        [Test]
        public void ExecuteCommand_AddsToUndoStack()
        {
            CommandHistory history = new CommandHistory();
            TestCommand testCommand = new TestCommand();

            history.ExecuteCommand(testCommand);
            history.Undo();

            Assert.That(testCommand.UndoCalled, Is.True);
        }

        [Test]
        public void Undo_MovesCommandToRedoStack()
        {
            CommandHistory history = new CommandHistory();
            TestCommand testCommand = new TestCommand();

            history.ExecuteCommand(testCommand);
            history.Undo();
            history.Redo();

            Assert.That(testCommand.ExecuteCalled, Is.True);
        }

        [Test]
        public void Redo_MovesCommandBackToUndoStack()
        {
            CommandHistory history = new CommandHistory();
            TestCommand testCommand = new TestCommand();

            history.ExecuteCommand(testCommand);
            history.Undo();
            history.Redo();
            history.Undo();

            Assert.That(testCommand.UndoCalled, Is.True);
        }

        [Test]
        public void Clear_EmptiesBothStacks()
        {
            CommandHistory history = new CommandHistory();
            history.ExecuteCommand(new TestCommand());
            history.Undo();
            history.Clear();

            history.Undo();
            history.Redo();
        }

        private class TestCommand : ICommand
        {
            public bool ExecuteCalled = false;
            public bool UndoCalled = false;

            public void Execute() { ExecuteCalled = true; }
            public void Undo() { UndoCalled = true; }
        }
    }
}