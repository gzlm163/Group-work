namespace JobSearchPlatform {
  public class ChangeNameCommand(Resume targetResume, string newNameValuee) : ICommand {
    private readonly Resume _resume = targetResume;
    private readonly string _oldValue = targetResume.Name;
    private readonly string _newValue = newNameValuee;

    public void Execute() {
      _resume.Name = _newValue;
    }

    public void Undo() {
      _resume.Name = _oldValue;
    }
  }
}