using System.IO;
using System.Text;

namespace JobSearchPlatform {
  public class ResumeRepository {
    private const string FileName = "resume.txt";

    public Resume? Load() {
      if (!File.Exists(FileName)) {
        return null;
      }

      try {
        string line = File.ReadAllText(FileName, Encoding.UTF8);
        string[] parts = line.Split('|');

        if (parts.Length != 4) {
          return null;
        }

        Resume resume = new Resume {
          Name = parts[0],
          Experience = int.Parse(parts[1]),
          Skills = parts[2],
          Salary = int.Parse(parts[3])
        };

        return resume;
      }
      catch {
        return null;
      }
    }

    public void Save(Resume resume) {
      string line = resume.Name + "|" + resume.Experience + "|" + resume.Skills + "|" + resume.Salary;
      File.WriteAllText(FileName, line, Encoding.UTF8);
    }
  }
}