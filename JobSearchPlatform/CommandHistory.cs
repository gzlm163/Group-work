using System.Collections.Generic;

namespace JobSearchPlatform {
  public class CommandHistory {
    private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
    private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();
    private const int MaxHistory = 10;


    /// <summary>Executes a command and adds it to the undo stack</summary>
    /// <param name="command">The command to execute</param>
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

    /// <summary>Undoes the last executed command</summary>
    public void Undo() {
      if (_undoStack.Count == 0) {
        return;
      }
      ICommand command = _undoStack.Pop();
      command.Undo();
      _redoStack.Push(command);
    }

    /// <summary>Redoes the last undone command</summary>
    public void Redo() {
      if (_redoStack.Count == 0) {
        return;
      }
      ICommand command = _redoStack.Pop();
      command.Execute();
      _undoStack.Push(command);
    }

    /// <summary>Clears both undo and redo stacks</summary>
    public void Clear() {
      _undoStack.Clear();
      _redoStack.Clear();
    }
  }
}
