using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay2.Models
{
    public class Project
    {
        public Project()
        {
            Emp_Projs= new List<Emp_Proj>();
        }
        [Key]
        public int Number { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        public virtual Department department { get; set; }
        [ForeignKey("department")]
        public int Dept_id { get; set; }
        public virtual List<Emp_Proj> Emp_Projs { get; set; }

    }
}
