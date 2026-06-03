using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchPlatform {
  public class VacancyView {
    public void ShowMainMenu() {
      Console.WriteLine("\n--- УПРАВЛЕНИЕ ВАКАНСИЯМИ ---");
      Console.WriteLine("1. Показать все вакансии");
      Console.WriteLine("2. Добавить вакансию");
      Console.WriteLine("3. Удалить вакансию");
      Console.WriteLine("4. Назад");
      Console.Write("Выберите действие: ");
    }

    public int GetUserChoice() {
      string input = Console.ReadLine();

      if (int.TryParse(input, out int choice)) {
        return choice;
      }

      return -1;
    }

    public void ShowAllVacancies(List<Vacancy> vacancies) {
      if (vacancies.Count == 0) {
        Console.WriteLine("\nСписок вакансий пуст");
        return;
      }

      Console.WriteLine("\n=== СПИСОК ВАКАНСИЙ ===");

      foreach (Vacancy vacancy in vacancies) {
        Console.WriteLine($"{vacancy.Id}. {vacancy.Title} | {vacancy.Company} | {vacancy.Salary} руб. | {vacancy.Type}");
      }
    }

    public (string title, string company, int salary, string type) GetNewVacancyData() {
      Console.Write("Название: ");
      string title = Console.ReadLine();

      Console.Write("Компания: ");
      string company = Console.ReadLine();

      Console.Write("Зарплата: ");
      string salaryInput = Console.ReadLine();

      if (!int.TryParse(salaryInput, out int salary) || salary <= 0) {
        Console.WriteLine("Ошибка: зарплата должна быть положительным числом");
        return (null, null, 0, null);
      }

      Console.WriteLine("Тип вакансии:");
      Console.WriteLine("1 - IT");
      Console.WriteLine("2 - Marketing");
      Console.WriteLine("3 - Sales");
      Console.Write("Выберите (1-3): ");

      string typeChoice = Console.ReadLine();
      string type = "";

      switch (typeChoice) {
        case "1":
          type = "IT";
          break;
        case "2":
          type = "Marketing";
          break;
        case "3":
          type = "Sales";
          break;
        default:
          Console.WriteLine("Ошибка: неверный выбор типа вакансии");
          return (null, null, 0, null);
      }

      return (title, company, salary, type);
    }

    public int GetIdForDelete() {
      Console.Write("Введите ID вакансии для удаления: ");
      string input = Console.ReadLine();

      if (int.TryParse(input, out int id)) {
        return id;
      }

      return -1;
    }

    public void ShowSuccess(string message) {
      Console.WriteLine(message);
    }

    public void ShowError(string message) {
      Console.WriteLine($"Ошибка: {message}");
    }

    public void WaitForKey() {
      Console.WriteLine("\nНажмите любую клавишу для продолжения...");
      Console.ReadKey();
    }
  }
}
