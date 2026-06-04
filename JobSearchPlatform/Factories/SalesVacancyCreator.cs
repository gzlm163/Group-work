using JobSearchPlatform.Models;

namespace JobSearchPlatform {
  public class SalesVacancyCreator : VacancyCreator {
    public override Vacancy Create(string title, string company, int salary) {
      return new Vacancy {
        Title = title,
        Company = company,
        Salary = salary,
        Type = "Sales"
      };
    }
  }
}
