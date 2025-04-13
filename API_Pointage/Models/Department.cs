using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Pointage.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DepartmentId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le Departement doit contenir entre 2 et 50 caractères.")]
        public required string DepartmentName { get; set; }
    }
}
