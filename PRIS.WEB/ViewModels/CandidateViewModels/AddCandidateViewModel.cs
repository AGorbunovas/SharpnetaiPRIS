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

        [Required(ErrorMessage = "Įveskite vardą")]
        [Display(Name = "Vardas")]
        [RegularExpression("[^0-9]+$", ErrorMessage = "Vardui naudokite tik raides")]
        [StringLength(20, ErrorMessage = "{0} turi būti ne trumpesnis nei {2} ir ne ilgesnis nei {1} simbolių.", MinimumLength = 3)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Įveskite pavardę")]
        [Display(Name = "Pavardė")]
        [RegularExpression("[^0-9]+$", ErrorMessage = "Pavardei naudokite tik raides")]
        [StringLength(30, ErrorMessage = "{0} turi būti ne trumpesnis nei {2} ir ne ilgesnis {1} simbolių.", MinimumLength = 4)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Įveskite elektroninį paštą")]
        [Display(Name = "El. Paštas")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Įveskite telefono numerį")]
        [Display(Name = "Telefonas")]
        [RegularExpression(@"^[8][6]\d{7}$", ErrorMessage = "Įveskite telefono numerį formatu 86xxxxxxx")]
        public int? Phone { get; set; }

        [Display(Name = "Lytis")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Pasirinkite testą")]
        [Display(Name = "Testas")]
        public int? TestId { get; set; }

        [Display(Name = "Komentaras")]
        public string Comment { get; set; }

        [Display(Name = "Mokymosi programos")]
        public int?[] SelectedModuleIds { get; set; }
       
        public List<SelectListItem> Modules { get; set; }

        public List<SelectListItem> Tests { get; set; }
    }
}
