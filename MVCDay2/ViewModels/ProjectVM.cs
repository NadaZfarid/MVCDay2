using MVCDay2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MVCDay2.CustomAttribute;

namespace MVCDay2.ViewModels
{
    public class ProjectVM
    {
        public int Number { get; set; }
        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be more or equal 5 letters")]
        [Unique]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Location is required")]
        //[Remote("validateLocation", "Location", ErrorMessage = "Location Must be in Cairo, Alex or Giza.")]
        public string Location { get; set; }
        public int? Dept_id { get; set; }
        [Display(Name = "Confirm Location")]
        [Compare("Location", ErrorMessage = "Please Confirm The Location")]
        public string ConfirmLocation { get; set; }
    }
}
