namespace JobSearchPlatform {
  public class ITVacancyCreator : VacancyCreator {
    public override Vacancy Create(string title, string company, int salary) {
      return new Vacancy {
        Title = title,
        Company = company,
        Salary = salary,
        Type = "IT"
      };
    }
  }
}
