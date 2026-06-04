using System.Collections.Generic;

namespace JobSearchPlatform {
  public interface IVacancyRepository {
    List<Vacancy> GetAll();
    void Add(Vacancy vacancy);
    void Delete(int id);
  }
}