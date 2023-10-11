namespace Laboratorium2.Models
{
    public class BirthModel
    {
        public string? Name { get; set; }
        public DateTime? Date { get; set; }

        public bool IsValid()
        {
            return Name != null && Date != null;
        }

        public int? Birth()
        {
            if (!Date.HasValue)
            {
                throw new ArgumentNullException("dateOfBirth", "Data urodzenia nie może być pusta.");
            }

            DateTime today = DateTime.Today;
            int age = today.Year - Date.Value.Year;

            // Sprawdzamy, czy już był urodziny w bieżącym roku
            if (Date.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

    }
}
