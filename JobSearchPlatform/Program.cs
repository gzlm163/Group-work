using JobSearchPlatform;
using System;

internal class Program {
  private static void Main() {
    while (true) {
      Console.Clear();
      Console.WriteLine("========================================");
      Console.WriteLine("        ПЛАТФОРМА ПОИСКА РАБОТЫ");
      Console.WriteLine("========================================");
      Console.WriteLine("1. Управление вакансиями");
      Console.WriteLine("2. Управление резюме");
      Console.WriteLine("3. Выйти");
      Console.Write("Выберите: ");

      string choice = Console.ReadLine();

      if (choice == "1") {
        VacancyRepository vacancyRepo = new VacancyRepository("vacancies.txt");
        VacancyView vacancyView = new VacancyView();
        VacancyController vacancyController = new VacancyController(vacancyRepo, vacancyView);
        vacancyController.Run();
      } else if (choice == "2") {
        ResumeRepository resumeRepo = new ResumeRepository();
        ResumeView resumeView = new ResumeView();
        ResumeController resumeController = new ResumeController(resumeRepo, resumeView);
        resumeController.Run();
      } else if (choice == "3") {
        break;
      }
    }
  }
}