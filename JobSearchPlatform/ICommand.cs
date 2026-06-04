namespace JobSearchPlatform {
  public interface ICommand {
    void Execute();
    void Undo();
  }
}