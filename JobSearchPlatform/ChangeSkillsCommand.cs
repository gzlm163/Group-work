namespace JobSearchPlatform {
  public class ChangeSkillsCommand(Resume targetResume, string newSalaryValue) : ICommand {
    private readonly Resume _resume = targetResume;
    private readonly string _oldValue = targetResume.Skills;
    private readonly string _newValue = newSalaryValue;

    public void Execute() {
      _resume.Skills = _newValue;
    }

    public void Undo() {
      _resume.Skills = _oldValue;
    }
  }
}
