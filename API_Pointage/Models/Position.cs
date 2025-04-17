using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API_Pointage.Models;

namespace API_Pointage.Models
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PositionId { get; set; } // Clé primaire

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le poste doit contenir entre 2 et 50 caractères.")]
        public required string PositionName { get; set; } // Exemple: "Développeur", "Technicien"

        public ICollection<Employee> Employees { get; set; } // Liste des employés occupant ce poste
    }
}
