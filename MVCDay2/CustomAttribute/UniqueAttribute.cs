using MVCDay2.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCDay2.CustomAttribute
{
    public class UniqueAttribute :ValidationAttribute
    {
        CompanyDbContext DB;
        public UniqueAttribute()
        {
                DB= new CompanyDbContext();
        }
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string? name = value as string;
            if (name == null) return ValidationResult.Success;

            Project? project = DB.Projects.FirstOrDefault(x => x.Name == name);
            if (project == null) return ValidationResult.Success;

            return new ValidationResult("Name is not valid");
        }
    }
}
