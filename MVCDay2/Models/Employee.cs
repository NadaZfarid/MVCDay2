using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay2.Models
{
    public class Employee
    {
        public Employee()
        {
            Dependents = new List<Dependent>();
            Emp_Projs = new List<Emp_Proj>();
            supers= new List<Employee>();
        }
        [Key]
        public int SSN { get; set; }
        [StringLength(50)]
        public string? Fname { get; set; }
        [StringLength(50)]
        public string? LName { get; set; }
        [StringLength(50)]
        public string? Address{ get; set; }
        [StringLength(1)]
        public string? Gender { get; set; }
        [Column(TypeName ="Date")]
        public DateTime? BDate { get; set; }
        [Column(TypeName = "money")]

        public double? Salary { get; set; }
        public virtual Employee super { get; set; }
        [ForeignKey("super")]
        public int? Super_SSN { get; set; }
        public virtual List<Dependent>? Dependents { get; set; }
        public virtual List<Emp_Proj>? Emp_Projs { get; set; }

        public virtual List<Employee>? supers { get; set; }

        public virtual Department? department { get; set; }
        [ForeignKey("department")]
        public int? Dept_id { get; set; }
        public virtual Department? manage { get; set; }


    }
}
