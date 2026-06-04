namespace JobSearchPlatform {
  public class ChangeSalaryCommand(Resume targetResume, int newSkillsValue) : ICommand {
    private readonly Resume _resume = targetResume;
    private readonly int _oldValue = targetResume.Salary;
    private readonly int _newValue = newSkillsValue;

    public void Execute() {
      _resume.Salary = _newValue;
    }

    public void Undo() {
      _resume.Salary = _oldValue;
    }
  }
}