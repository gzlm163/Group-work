using System;

namespace JobSearchPlatform {
  public class ResumeController {
    private Resume _currentResume;
    private readonly ResumeRepository _repo;
    private readonly ResumeView _view;
    private readonly CommandHistory _history;

    public ResumeController(ResumeRepository repo, ResumeView view) {
      _repo = repo;
      _view = view;
      _history = new CommandHistory();
      _currentResume = _repo.Load() ?? new Resume();
    }

    /// <summary>Main menu loop for resume management</summary>
    public void Run() {
      while (true) {
        _view.ShowMessage("\n=== УПРАВЛЕНИЕ РЕЗЮМЕ ===");
        _view.ShowMessage("1. Показать резюме");
        _view.ShowMessage("2. Создать/Перезаписать резюме");
        _view.ShowMessage("3. Изменить поле");
        _view.ShowMessage("4. Undo");
        _view.ShowMessage("5. Redo");
        _view.ShowMessage("6. Выйти");

        if (!int.TryParse(Console.ReadLine(), out int choice)) {
          _view.ShowMessage("Ошибка ввода. Введите число от 1 до 6.");
          continue;
        }

        if (choice == 1) {
          Show();
        } else if (choice == 2) {
          CreateOrOverwrite();
        } else if (choice == 3) {
          int field = _view.GetFieldNumber();
          ChangeField(field);
        } else if (choice == 4) {
          Undo();
        } else if (choice == 5) {
          Redo();
        } else if (choice == 6) {
          break;
        }
      }
    }

    /// <summary>Displays current resume</summary>
    public void Show() {
      _view.ShowResume(_currentResume);
    }

    /// <summary>Creates new resume or overwrites existing one</summary>
    public void CreateOrOverwrite() {
      if (_currentResume.Name != "Не указано") {
        if (!_view.AskForOverwrite()) {
          return;
        }
      }

      _currentResume = _view.GetNewResume();
      _repo.Save(_currentResume);
      _history.Clear();
      _view.ShowMessage("Резюме сохранено");
    }

    /// <summary>Changes specified field using command pattern</summary>
    /// <param name="field">Field number (1-4)</param>
    public void ChangeField(int field) {
      string newValue = _view.GetNewFieldValue(field);
      ICommand command = default!;

      if (field == 1) {
        command = new ChangeNameCommand(_currentResume, newValue);
      } else if (field == 2) {
        if (int.TryParse(newValue, out int exp)) {
          command = new ChangeExperienceCommand(_currentResume, exp);
        } else {
          _view.ShowMessage("Ошибка: опыт должен быть числом");
          return;
        }
      } else if (field == 3) {
        command = new ChangeSkillsCommand(_currentResume, newValue);
      } else if (field == 4) {
        if (int.TryParse(newValue, out int sal)) {
          command = new ChangeSalaryCommand(_currentResume, sal);
        } else {
          _view.ShowMessage("Ошибка: зарплата должна быть числом");
          return;
        }
      }

      if (command != null) {
        _history.ExecuteCommand(command);
        _repo.Save(_currentResume);
        _view.ShowMessage("Поле изменено");
      }
    }

    /// <summary>Undoes last action</summary>
    public void Undo() {
      _history.Undo();
      _repo.Save(_currentResume);
      _view.ShowMessage("Отмена выполнена");
    }

    /// <summary>Redoes last undone action</summary>
    public void Redo() {
      _history.Redo();
      _repo.Save(_currentResume);
      _view.ShowMessage("Повтор выполнен");
    }
  }
}