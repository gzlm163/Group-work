using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchPlatform {
  public abstract class VacancyCreator {
    public abstract Vacancy Create(string title, string company, int salary);
  }
}
