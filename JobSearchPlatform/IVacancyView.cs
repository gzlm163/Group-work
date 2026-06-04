using System.Collections.Generic;

namespace JobSearchPlatform {
  public interface IVacancyView {
    void ShowMainMenu();
    int GetUserChoice();
    void ShowAllVacancies(List<Vacancy> vacancies);
    (string title, string company, int salary, string type) GetNewVacancyData();
    int GetIdForDelete();
    void ShowSuccess(string message);
    void ShowError(string message);
    void WaitForKey();
  }
}