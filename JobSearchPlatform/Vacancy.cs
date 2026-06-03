using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchPlatform {
  public class Vacancy {
    private static readonly char Separator = '|';
    private static readonly int IdIndex = 0;
    private static readonly int TitleIndex = 1;
    private static readonly int CompanyIndex = 2;
    private static readonly int SalaryIndex = 3;
    private static readonly int TypeIndex = 4;

    public int Id { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public int Salary { get; set; }
    public string Type { get; set; }

    public string ToFileString() {
      return $"{Id}{Separator}{Title}{Separator}{Company}{Separator}{Salary}{Separator}{Type}";
    }

    public static Vacancy FromFileString(string line) {
      string[] parts = line.Split(Separator);
      return new Vacancy {
        Id = int.Parse(parts[IdIndex]),
        Title = parts[TitleIndex],
        Company = parts[CompanyIndex],
        Salary = int.Parse(parts[SalaryIndex]),
        Type = parts[TypeIndex]
      };
    }
  }
}
