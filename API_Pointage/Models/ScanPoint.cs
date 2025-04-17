using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API_Pointage.Models;

namespace API_Pointage.Models
{
    public class ScanPoint
    {
        [Key]
        public Guid ScanPointId { get; set; }
        public Guid EmployeeId { get; set; } // Référence à l'employé

        [Required]
        public required string Name { get; set; } // Exemple : "Entrée principale", "Zone de production"

        public string? Localisation { get; set; } // Optionnel : GPS ou nom de bâtiment

        [Required]
        public required string QrCodeValue { get; set; } // Valeur stockée pour le QR code

        public Guid EntrepriseId { get; set; }

        [ForeignKey("EntrepriseId")]
        public Entreprise Entreprise { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }

}
