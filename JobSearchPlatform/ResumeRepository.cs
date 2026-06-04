using System.IO;
using System.Text;

namespace JobSearchPlatform {
  public class ResumeRepository {
    private const string FileName = "resume.txt";
    private const char Delimiter = '|';
    private const int ExpectedPartsCount = 4;
    private const int NameIndex = 0;
    private const int ExperienceIndex = 1;
    private const int SkillsIndex = 2;
    private const int SalaryIndex = 3;

    /// <summary>Loads resume from file</summary>
    /// <returns>Resume object if file exists and valid, otherwise null</returns>
    public Resume Load() {
      if (!File.Exists(FileName)) {
        return null;
      }

      try {
        string line = File.ReadAllText(FileName, Encoding.UTF8);
        string[] parts = line.Split(Delimiter);

        if (parts.Length != ExpectedPartsCount) {
          return null;
        }

        Resume resume = new Resume {
          Name = parts[NameIndex],
          Experience = int.Parse(parts[ExperienceIndex]),
          Skills = parts[SkillsIndex],
          Salary = int.Parse(parts[SalaryIndex])
        };

        return resume;
      }
      catch {
        return null;
      }
    }

    /// <summary>Saves resume to file</summary>
    /// <param name="resume">Resume object to save</param>
    public void Save(Resume resume) {
      string line = resume.Name + Delimiter + resume.Experience + Delimiter + resume.Skills + Delimiter + resume.Salary;
      File.WriteAllText(FileName, line, Encoding.UTF8);
    }
  }
}