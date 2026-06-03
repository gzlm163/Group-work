namespace JobSearchPlatform {

  /// <summary>
  /// Модель резюме (POCO).
  /// </summary>
  public class Resume {
    /// <summary>Имя соискателя</summary>
    public string Name { get; set; } = "Не указано";
    /// <summary>Опыт работы в годах</summary>
    public int Experience { get; set; } = 0;
    /// <summary>Навыки (через запятую)</summary>
    public string Skills { get; set; } = "Нет";
    /// <summary>Желаемая зарплата</summary>
    public int Salary { get; set; } = 0;
  }
}