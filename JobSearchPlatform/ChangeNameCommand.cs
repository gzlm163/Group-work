namespace JobSearchPlatform {
  public class ChangeNameCommand(Resume resume, string newValue) : ICommand {
    private readonly Resume _resume = resume;
    private readonly string _oldValue = resume.Name;
    private readonly string _newValue = newValue;

    public void Execute() {
      _resume.Name = _newValue;
    }

    public void Undo() {
      _resume.Name = _oldValue;
    }
  }
}