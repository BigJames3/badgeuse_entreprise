using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API_Pointage.Models;

namespace API_Pointage.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DepartmentId { get; set; }  // Clé primaire

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le Departement doit contenir entre 2 et 50 caractères.")]
        public required string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
