using System;

namespace JobSearchPlatform {
  public class ResumeView {
    /// <summary>Displays all resume fields</summary>
    /// <param name="resume">Resume object to display</param>
    public void ShowResume(Resume resume) {
      Console.WriteLine("Имя: " + resume.Name);
      Console.WriteLine("Опыт: " + resume.Experience);
      Console.WriteLine("Навыки: " + resume.Skills);
      Console.WriteLine("Зарплата: " + resume.Salary);
    }

    /// <summary>Gets new resume data from user input</summary>
    /// <returns>New Resume object with user data</returns>
    public Resume GetNewResume() {
      Console.Write("Имя: ");
      string userName;
      userName = Console.ReadLine() ?? "Не указано";

      Console.Write("Опыт: ");
      int userExperience;
      if (int.TryParse(Console.ReadLine(), out int exp)) {
        userExperience = exp;
      } else {
        userExperience = 0;
      }

      Console.Write("Навыки: ");
      string userSkills = Console.ReadLine() ?? "Нет";

      Console.Write("Зарплата: ");
      int userSalary;
      if (int.TryParse(Console.ReadLine(), out int sal)) {
        userSalary = sal;
      } else {
        userSalary = 0;
      }

      return new Resume {
        Name = userName,
        Experience = userExperience,
        Skills = userSkills,
        Salary = userSalary
      };
    }

    /// <summary>Shows field selection menu and returns selected number</summary>
    /// <returns>Selected field number (1-4) or 0 if invalid</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Преобразовать в условное выражение", Justification = "<Ожидание>")]
    public int GetFieldNumber() {
      Console.WriteLine("1 - Имя");
      Console.WriteLine("2 - Опыт");
      Console.WriteLine("3 - Навыки");
      Console.WriteLine("4 - Зарплата");
      Console.Write("Выберите поле: ");

      if (int.TryParse(Console.ReadLine(), out int field)) {
        return field;
      } else {
        return 0;
      }
    }

    /// <summary>Gets new value for specified field</summary>
    /// <param name="fieldNumber">Field number (1-4)</param>
    /// <returns>New value as string</returns>
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

    /// <summary>Asks user to confirm resume overwrite</summary>
    /// <returns>True if user confirms, false otherwise</returns>
    public bool AskForOverwrite() {
      Console.Write("Резюме уже есть. Перезаписать? (да/нет): ");
      string userAnswer = Console.ReadLine() ?? "";

      bool isOverwrite = userAnswer == "да";
      return isOverwrite;
    }

    /// <summary>Shows a message to the user</summary>
    /// <param name="message">Message to display</param>
    public void ShowMessage(string message) {
      Console.WriteLine(message);
    }
  }
}