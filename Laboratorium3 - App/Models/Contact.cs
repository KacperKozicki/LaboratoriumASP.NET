﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public class Contact
    {
        [HiddenInput]
        public DateTime Created { get; set; }


        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać imię!")]
        [StringLength(maximumLength:50,ErrorMessage="Zbyt długie imie, max 50 znaków")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; } // TYP? nie jest wymagane (opcjonalne pole)

        [Display(Name = "Data ur.")]
        public DateTime? Birth { get; set; }

        [Display(Name = "Ważność")]
        public Priority Priority { get; set; }
    }
}
