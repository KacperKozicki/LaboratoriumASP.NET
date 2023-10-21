using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać imię!")]
        [StringLength(maximumLength:50,ErrorMessage="Zbyt długie imie, max 50 znaków")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        
        public string? Phone { get; set; } // TYP? nie jest wymagane (opcjonalne pole)
        public DateTime? Birth { get; set; }
    }
}
