using JobSearchPlatform.Models;

namespace JobSearchPlatform {
  public abstract class VacancyCreator {
    /// <summary>
    /// Создаёт объект Vacancy с заданными параметрами
    /// </summary>
    public abstract Vacancy Create(string title, string company, int salary);
  }
}