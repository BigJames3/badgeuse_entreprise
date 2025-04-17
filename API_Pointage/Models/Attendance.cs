using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API_Pointage.Models;

namespace API_Pointage.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AttendanceId { get; set; }  // Identifiant unique de l'enregistrement de présence
        public Guid EmployeeId { get; set; }  // Référence à l'employé
        public Guid ScanPointId { get; set; } // Lieu de scan

        public DateTime CheckInTime { get; set; }  // Heure de pointage (entrée)
        public DateTime? CheckOutTime { get; set; }  // Heure de départ (sortie) (nullable)
        public DateTime Date { get; set; }  // Date de l'enregistrement de présence
        public DateTime DateNow { get; set; } = DateTime.UtcNow.Date;  // Date de l'enregistrement de présence
        public TimeSpan? TotalDuration { get; set; } // Durée de présence calculée automatiquement
        public string MethodUsed { get; set; } = "QR"; // Méthode de pointage ("QR", "NFC", etc.)
        public string? Comment { get; set; } // Commentaire optionnel sur la présence

        // Navigation properties
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }  // Navigation property[ForeignKey("ScanPointId")]
        public ScanPoint ScanPoint { get; set; }
    }
}
