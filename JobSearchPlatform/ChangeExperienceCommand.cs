namespace JobSearchPlatform {
  public class ChangeExperienceCommand(Resume resume, int newValue) : ICommand {
    private readonly Resume _resume = resume;
    private readonly int _oldValue = resume.Experience;
    private readonly int _newValue = newValue;

    public void Execute() {
      _resume.Experience = _newValue;
    }

    public void Undo() {
      _resume.Experience = _oldValue;
    }
  }
}
