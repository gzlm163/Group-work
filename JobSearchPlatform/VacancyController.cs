using System.Collections.Generic;

namespace JobSearchPlatform {
  public class VacancyController {
    private readonly IVacancyRepository _repository;
    private readonly IVacancyView _view;
    private readonly Dictionary<string, VacancyCreator> _creators;

    public VacancyController(IVacancyRepository repository, IVacancyView view) {
      _repository = repository;
      _view = view;
      _creators = new Dictionary<string, VacancyCreator>
      {
        { "IT", new ITVacancyCreator() },
        { "Marketing", new MarketingVacancyCreator() },
        { "Sales", new SalesVacancyCreator() }
    };
    }

    /// <summary>
    /// Запускает главное меню управления вакансиями и обрабатывает выбор пользователя
    /// </summary>
    public void Run() {
      while (true) {
        _view.ShowMainMenu();
        int choice = _view.GetUserChoice();

        switch (choice) {
          case 1:
            ShowAllVacancies();
            break;
          case 2:
            AddVacancy();
            break;
          case 3:
            DeleteVacancy();
            break;
          case 4:
            return;
          default:
            _view.ShowError("Неверный выбор. Попробуйте снова.");
            _view.WaitForKey();
            break;
        }
      }
    }

    private void ShowAllVacancies() {
      List<Vacancy> vacancies = _repository.GetAll();
      _view.ShowAllVacancies(vacancies);
      _view.WaitForKey();
    }

    /// <summary>
    /// Добавляет новую вакансию
    /// </summary>
    public void AddVacancy() {
      (string title, string company, int salary, string type) = _view.GetNewVacancyData();

      if (title == null || company == null || type == null) {
        return;
      }

      if (!_creators.ContainsKey(type)) {
        _view.ShowError("Неизвестный тип вакансии");
        _view.WaitForKey();
        return;
      }

      VacancyCreator creator = _creators[type];
      Vacancy newVacancy = creator.Create(title, company, salary);

      _repository.Add(newVacancy);
      _view.ShowSuccess($"Вакансия \"{title}\" добавлена с ID = {newVacancy.Id}");
      _view.WaitForKey();
    }

    /// <summary>
    /// Удаляет вакансию по ID, запрашивая его у пользователя
    /// </summary>
    public void DeleteVacancy() {
      List<Vacancy> vacancies = _repository.GetAll();

      if (vacancies.Count == 0) {
        _view.ShowError("Нет вакансий для удаления");
        _view.WaitForKey();
        return;
      }

      _view.ShowAllVacancies(vacancies);
      int id = _view.GetIdForDelete();

      if (id == -1) {
        return;
      }

      bool found = false;
      string deletedTitle = "";

      foreach (Vacancy vacancy in vacancies) {
        if (vacancy.Id == id) {
          found = true;
          deletedTitle = vacancy.Title;
          break;
        }
      }

      if (!found) {
        _view.ShowError($"Вакансия с ID = {id} не найдена");
        _view.WaitForKey();
        return;
      }

      _repository.Delete(id);
      _view.ShowSuccess($"Вакансия \"{deletedTitle}\" удалена");
      _view.WaitForKey();
    }
  }
}