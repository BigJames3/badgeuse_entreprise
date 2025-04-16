using System.ComponentModel.DataAnnotations;

namespace API_Pointage.Models
{
    public class Entreprise
    {
        [Key]
        public Guid EntrepriseId { get; set; }

        [Required]
        public required string Nom { get; set; }

        public TimeSpan HeureArriveePrevue { get; set; } // Heure de début de journée prévue
        public TimeSpan HeureDepartPrevue { get; set; } // Heure de fin de journée prévue

        public ICollection<Employee> Employees { get; set; } // Employés de l’entreprise
        public ICollection<ScanPoint> ScanPoints { get; set; } // Points de contrôle liés à cette entreprise
    }

}
