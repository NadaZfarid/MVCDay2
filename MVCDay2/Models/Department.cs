using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay2.Models
{
    public class Department
    {
        public Department()
        {
            Projects = new List<Project>();
            Dept_Locs = new List<Dept_loc>();
            Employees = new List<Employee>();
        }
        [Key]
        public int Number { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual List<Project>? Projects { get; set; }
        public virtual List<Dept_loc>? Dept_Locs { get; set; }

        public virtual List<Employee>? Employees { get; set; }
        
        public virtual Employee? employee { get; set; }
        [ForeignKey("employee")]
        public int? Manage_SSN { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }

    }
}
