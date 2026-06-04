using JobSearchPlatform.Interfaces;
using JobSearchPlatform.Models;

namespace JobSearchPlatform {
  public class ChangeExperienceCommand(Resume targetResume, int newExperienceValue) : ICommand {
    private readonly Resume _resume = targetResume;
    private readonly int _oldValue = targetResume.Experience;
    private readonly int _newValue = newExperienceValue;

    public void Execute() {
      _resume.Experience = _newValue;
    }

    public void Undo() {
      _resume.Experience = _oldValue;
    }
  }
}
