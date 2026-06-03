using System;
namespace JobSearchPlatform {
  internal class Program {
    private static void Main(string[] args) {
      ArgumentNullException.ThrowIfNull(args);
      Console.WriteLine("=== ПЛАТФОРМА ДЛЯ ПОИСКА РАБОТЫ ===\n");

      ResumeRepository repo = new ResumeRepository();
      ResumeView view = new ResumeView();
      ResumeController controller = new ResumeController(repo, view);

      controller.Run();

      Console.WriteLine("\nДо свидания!");
    }
  }
}