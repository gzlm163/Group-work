using System;

namespace JobSearchPlatform {
  public class ResumeController {
    private Resume _currentResume;
    private readonly ResumeRepository _resumeRepository;
    private readonly ResumeView _resumeView;
    private readonly CommandHistory _commandHistory;

    public ResumeController(ResumeRepository resumeRepository, ResumeView resumeView) {
      _resumeRepository = resumeRepository;
      _resumeView = resumeView;
      _commandHistory = new CommandHistory();
      _currentResume = _resumeRepository.Load() ?? new Resume();
    }

    /// <summary>Main menu loop for resume management</summary>
    public void Run() {
      while (true) {
        _resumeView.ShowMessage("\n=== УПРАВЛЕНИЕ РЕЗЮМЕ ===");
        _resumeView.ShowMessage("1. Показать резюме");
        _resumeView.ShowMessage("2. Создать/Перезаписать резюме");
        _resumeView.ShowMessage("3. Изменить поле");
        _resumeView.ShowMessage("4. Undo");
        _resumeView.ShowMessage("5. Redo");
        _resumeView.ShowMessage("6. Выйти");

        if (!int.TryParse(Console.ReadLine(), out int menuOption)) {
          _resumeView.ShowMessage("Ошибка ввода. Введите число от 1 до 6.");
          continue;
        }

        if (menuOption == 1) {
          Show();
        } else if (menuOption == 2) {
          CreateOrOverwrite();
        } else if (menuOption == 3) {
          int field = _resumeView.GetFieldNumber();
          ChangeField(field);
        } else if (menuOption == 4) {
          Undo();
        } else if (menuOption == 5) {
          Redo();
        } else if (menuOption == 6) {
          break;
        }
      }
    }

    /// <summary>Displays current resume</summary>
    public void Show() {
      _resumeView.ShowResume(_currentResume);
    }

    /// <summary>Creates new resume or overwrites existing one</summary>
    public void CreateOrOverwrite() {
      if (_currentResume.Name != "Не указано") {
        if (!_resumeView.AskForOverwrite()) {
          return;
        }
      }

      _currentResume = _resumeView.GetNewResume();
      _resumeRepository.Save(_currentResume);
      _commandHistory.Clear();
      _resumeView.ShowMessage("Резюме сохранено");
    }

    /// <summary>Changes specified selectedFieldNumber using command pattern</summary>
    /// <param name="selectedFieldNumber">Field number (1-4)</param>
    public void ChangeField(int selectedFieldNumber) {
      string newFieldValue = _resumeView.GetNewFieldValue(selectedFieldNumber);
      ICommand command = default!;

      if (selectedFieldNumber == 1) {
        command = new ChangeNameCommand(_currentResume, newFieldValue);
      } else if (selectedFieldNumber == 2) {
        if (int.TryParse(newFieldValue, out int experienceValue)) {
          command = new ChangeExperienceCommand(_currentResume, experienceValue);
        } else {
          _resumeView.ShowMessage("Ошибка: опыт должен быть числом");
          return;
        }
      } else if (selectedFieldNumber == 3) {
        command = new ChangeSkillsCommand(_currentResume, newFieldValue);
      } else if (selectedFieldNumber == 4) {
        if (int.TryParse(newFieldValue, out int salaryValue)) {
          command = new ChangeSalaryCommand(_currentResume, salaryValue);
        } else {
          _resumeView.ShowMessage("Ошибка: зарплата должна быть числом");
          return;
        }
      }

      if (command != null) {
        _commandHistory.ExecuteCommand(command);
        _resumeRepository.Save(_currentResume);
        _resumeView.ShowMessage("Поле изменено");
      }
    }

    /// <summary>Undoes last action</summary>
    public void Undo() {
      _commandHistory.Undo();
      _resumeRepository.Save(_currentResume);
      _resumeView.ShowMessage("Отмена выполнена");
    }

    /// <summary>Redoes last undone action</summary>
    public void Redo() {
      _commandHistory.Redo();
      _resumeRepository.Save(_currentResume);
      _resumeView.ShowMessage("Повтор выполнен");
    }
  }
}