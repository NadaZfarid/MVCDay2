using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay2.Models
{
    public class Emp_Proj
    {
        public virtual Employee employee { get; set; }
        [ForeignKey("employee")]
        public int Emp_SSN { get; set; }
        public virtual Project project { get; set; }
        [ForeignKey("project")]
        public int Proj_Id { get; set; }

        public int Hours { get; set; }
    }
}
