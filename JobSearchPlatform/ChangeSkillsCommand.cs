namespace JobSearchPlatform {
  public class ChangeSkillsCommand(Resume resume, string newValue) : ICommand {
    private readonly Resume _resume = resume;
    private readonly string _oldValue = resume.Skills;
    private readonly string _newValue = newValue;

    public void Execute() {
      _resume.Skills = _newValue;
    }

    public void Undo() {
      _resume.Skills = _oldValue;
    }
  }
}
