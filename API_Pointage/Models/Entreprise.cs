using System.ComponentModel.DataAnnotations;
using API_Pointage.Models;

namespace API_Pointage.Models
{
    public class Entreprise
    {
        [Key]
        public Guid EntrepriseId { get; set; } // GUID généré automatiquement comme clé primaire

        [Required] // L'entreprise doit avoir un nom
        [MaxLength(200)] // La longueur maximale du nom de l'entreprise
        public string NomEntreprise { get; set; } // Nom de l'entreprise

        [MaxLength(500)] // La longueur maximale de l'adresse
        public string Adresse { get; set; } // Adresse de l'entreprise

        [Required] // L'entreprise doit avoir un email
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; } // Email de l'entreprise

        [Required] // Date de création obligatoire
        public DateTime CreatedAt { get; set; } // Date de création de l'entreprise

        public TimeSpan HeureArriveePrevue { get; set; } // Heure de début de journée prévue
        public TimeSpan HeureDepartPrevue { get; set; } // Heure de fin de journée prévue

        // Relations avec les autres entités
        public ICollection<Employee> Employees { get; set; } // Employés associés à cette entreprise
        public ICollection<ScanPoint> ScanPoints { get; set; } // Points de contrôle liés à cette entreprise
    }
}
