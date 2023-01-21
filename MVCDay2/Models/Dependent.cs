using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCDay2.Models
{
    public class Dependent
    {
        public string Name { get; set; }
        [StringLength(1)]
        public char? Gender { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? BDate { get; set; }
        public string Relationship { get; set; }
        public virtual Employee employee { get; set; }
        [ForeignKey("employee")]
        public int Emp_SSN { get; set; }
    }
}
