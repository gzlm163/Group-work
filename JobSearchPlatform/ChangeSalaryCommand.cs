namespace JobSearchPlatform {
  public class ChangeSalaryCommand(Resume resume, int newValue) : ICommand {
    private readonly Resume _resume = resume;
    private readonly int _oldValue = resume.Salary;
    private readonly int _newValue = newValue;

    public void Execute() {
      _resume.Salary = _newValue;
    }

    public void Undo() {
      _resume.Salary = _oldValue;
    }
  }
}