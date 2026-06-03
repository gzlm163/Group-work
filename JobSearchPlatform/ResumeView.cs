using System;

namespace JobSearchPlatform {
  public class ResumeView {
    public void ShowResume(Resume resume) {
      Console.WriteLine("Имя: " + resume.Name);
      Console.WriteLine("Опыт: " + resume.Experience);
      Console.WriteLine("Навыки: " + resume.Skills);
      Console.WriteLine("Зарплата: " + resume.Salary);
    }
    public Resume GetNewResume() {
      Console.Write("Имя: ");
      string userName = Console.ReadLine() ?? "Не указано";

      Console.Write("Опыт: ");
      int userExperience = int.TryParse(Console.ReadLine(), out int exp) ? exp : 0;

      Console.Write("Навыки: ");
      string userSkills = Console.ReadLine() ?? "Нет";

      Console.Write("Зарплата: ");
      int userSalary = int.TryParse(Console.ReadLine(), out int sal) ? sal : 0;

      Resume newResume = new Resume {
        Name = userName,
        Experience = userExperience,
        Skills = userSkills,
        Salary = userSalary
      };

      return newResume;
    }
    public int GetFieldNumber() {
      Console.WriteLine("1 - Имя");
      Console.WriteLine("2 - Опыт");
      Console.WriteLine("3 - Навыки");
      Console.WriteLine("4 - Зарплата");
      Console.Write("Выберите поле: ");

      int fieldNumber = int.TryParse(Console.ReadLine(), out int field) ? field : 0;
      return fieldNumber;
    }

    public string GetNewFieldValue(int fieldNumber) {
      if (fieldNumber == 1) {
        Console.Write("Новое имя: ");
      } else if (fieldNumber == 2) {
        Console.Write("Новый опыт: ");
      } else if (fieldNumber == 3) {
        Console.Write("Новые навыки: ");
      } else {
        Console.Write("Новая зарплата: ");
      }
      return Console.ReadLine() ?? "";
    }

    public bool AskForOverwrite() {
      Console.Write("Резюме уже есть. Перезаписать? (да/нет): ");
      string userAnswer = Console.ReadLine() ?? "";

      bool isOverwrite = userAnswer == "да";
      return isOverwrite;
    }

    public void ShowMessage(string message) {
      Console.WriteLine(message);
    }
  }
}