namespace JobSearchPlatform.Interfaces {
  public interface ICommand {
    void Execute();
    void Undo();
  }
}