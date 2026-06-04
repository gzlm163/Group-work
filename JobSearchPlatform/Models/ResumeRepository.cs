using System.IO;
using System.Text;

namespace JobSearchPlatform.Models {
  public class ResumeRepository {
    private const string FileName = "resume.txt";
    private const char Delimiter = '|';
    private const int ExpectedPartsCount = 4;
    private const int NameIndex = 0;
    private const int ExperienceIndex = 1;
    private const int SkillsIndex = 2;
    private const int SalaryIndex = 3;

    /// <summary>Loads loadedResume from file</summary>
    /// <returns>Resume object if file exists and valid, otherwise null</returns>
    public Resume? Load() {
      if (!File.Exists(FileName)) {
        return null;
      }

      try {
        string fileContent = File.ReadAllText(FileName, Encoding.UTF8);
        string[] fieldParts = fileContent.Split(Delimiter);

        if (fieldParts.Length != ExpectedPartsCount) {
          return null;
        }

        Resume loadedResume = new Resume {
          Name = fieldParts[NameIndex],
          Experience = int.Parse(fieldParts[ExperienceIndex]),
          Skills = fieldParts[SkillsIndex],
          Salary = int.Parse(fieldParts[SalaryIndex])
        };

        return loadedResume;
      }
      catch {
        return null;
      }
    }

    /// <summary>Saves loadedResume to file</summary>
    /// <param name="resume">Resume object to save</param>
    public void Save(Resume resume) {
      string fileLine = resume.Name + Delimiter + resume.Experience + Delimiter + resume.Skills + Delimiter + resume.Salary;
      File.WriteAllText(FileName, fileLine, Encoding.UTF8);
    }
  }
}