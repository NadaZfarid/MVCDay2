using MVCDay2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay2.ViewModels
{
    public class Emp_ProjVM
    {
        [Display(Name = "Emoployee Name")]
        public int? Emp_SSN { get; set; }
        [Display(Name ="Project Name")]
        public int? Proj_Id { get; set; }

        public int? Hours { get; set; }
    }
}
