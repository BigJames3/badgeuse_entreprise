using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Pointage.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AttendanceId { get; set; }  // Identifiant unique de l'enregistrement de présence
        public Guid EmployeeId { get; set; }  // Référence à l'employé
        public DateTime CheckInTime { get; set; }  // Heure de pointage (entrée)
        public DateTime? CheckOutTime { get; set; }  // Heure de départ (sortie)
        public DateTime Date { get; set; }  // Date de l'enregistrement de présence

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }  // Navigation property
    }
}
