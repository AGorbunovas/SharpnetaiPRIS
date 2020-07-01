using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PRIS.WEB.Models;

namespace PRIS.WEB.ViewModels.CandidateViewModels
{
    public class AddCandidateViewModel
    {
        public int CandidateID { set; get; }

        [Required(ErrorMessage = "Įveskite...")]
        [Display(Name = "Vardas")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Įveskite...")]
        [Display(Name = "Pavardė")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Įveskite...")]
        [Display(Name = "El. Paštas")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Įveskite...")]
        [Display(Name = "Telefonas")]
        public int? Phone { get; set; }

        [Display(Name = "Lytis")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Įveskite...")]
        [Display(Name = "Testas")]
        public int TestId { get; set; }

        [Display(Name = "Komentaras")]
        public string Comment { get; set; }

        [Display(Name = "Mokymosi programos")]
        public int?[] SelectedModuleIds { get; set; }

        public List<SelectListItem> Modules { get; set; }

        public List<SelectListItem> Tests { get; set; }
    }
}
