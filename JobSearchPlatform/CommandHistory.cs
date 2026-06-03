using System.Collections.Generic;

namespace JobSearchPlatform {
  public class CommandHistory {
    private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
    private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();
    private const int MaxHistory = 10;
    public void ExecuteCommand(ICommand command) {
      if (command == null) {
        return;
      }

      command.Execute();
      _undoStack.Push(command);
      _redoStack.Clear();

      while (_undoStack.Count > MaxHistory) {
        RemoveBottomCommand();
      }
    }

    private void RemoveBottomCommand() {
      Stack<ICommand> temp = new Stack<ICommand>();
      while (_undoStack.Count > 1) {
        temp.Push(_undoStack.Pop());
      }
      _ = _undoStack.Pop();
      while (temp.Count > 0) {
        _undoStack.Push(temp.Pop());
      }
    }
    public void Undo() {
      if (_undoStack.Count == 0) {
        return;
      }
      ICommand command = _undoStack.Pop();
      command.Undo();
      _redoStack.Push(command);
    }

    public void Redo() {
      if (_redoStack.Count == 0) {
        return;
      }
      ICommand command = _redoStack.Pop();
      command.Execute();
      _undoStack.Push(command);
    }

    public void Clear() {
      _undoStack.Clear();
      _redoStack.Clear();
    }
  }
}
