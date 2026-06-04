using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchPlatform {
  public class VacancyRepository {
    private readonly string _filePath;
    public VacancyRepository(string filePath) {
      _filePath = filePath;
    }

    public List<Vacancy> GetAll() {
      if (!File.Exists(_filePath)) {
        return new List<Vacancy>();
      }

      string[] lines = File.ReadAllLines(_filePath);
      List<Vacancy> vacancies = new List<Vacancy>();

      foreach (string line in lines) {
        if (string.IsNullOrWhiteSpace(line)) {
          continue;
        }

        try {
          vacancies.Add(Vacancy.FromFileString(line));
        }
        catch {
          Console.WriteLine("Ошибка при чтении файла");
        }
      }

      return vacancies;
    }

    private void SaveAll(List<Vacancy> vacancies) {
      List<string> lines = new List<string>();

      foreach (Vacancy vacancy in vacancies) {
        lines.Add(vacancy.ToFileString());
      }

      File.WriteAllLines(_filePath, lines.ToArray());
    }

    public void Add(Vacancy vacancy) {
      List<Vacancy> allVacancies = GetAll();

      if (allVacancies.Count > 0) {
        int maxId = allVacancies[0].Id;

        foreach (Vacancy existingVacancy in allVacancies) {
          if (existingVacancy.Id > maxId) {
            maxId = existingVacancy.Id;
          }
        }

        vacancy.Id = maxId + 1;
      } else {
        vacancy.Id = 1;
      }

      allVacancies.Add(vacancy);
      SaveAll(allVacancies);
    }

    public void Delete(int id) {
      List<Vacancy> allVacancies = GetAll();
      List<Vacancy> filteredVacancies = new List<Vacancy>();

      foreach (Vacancy vacancy in allVacancies) {
        if (vacancy.Id != id) {
          filteredVacancies.Add(vacancy);
        }
      }

      SaveAll(filteredVacancies);
    }
  }
}
