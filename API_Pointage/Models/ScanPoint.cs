using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Pointage.Models
{
    public class ScanPoint
    {
        [Key]
        public Guid ScanPointId { get; set; }

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
