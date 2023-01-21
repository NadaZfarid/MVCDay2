using System.ComponentModel.DataAnnotations;

namespace MVCDay2.Models
{
    public class Department
    {
        public Department()
        {
            Projects = new List<Project>();
            Dept_Locs = new List<Dept_loc>();
        }
        [Key]
        public int Number { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual List<Project> Projects { get; set; }
        public virtual List<Dept_loc> Dept_Locs { get; set; }

    }
}
