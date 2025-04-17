using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using API_Pointage.Models;

namespace API_Pointage.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; } // GUID généré automatiquement //  Utilisation de GUID comme clé primaire

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le prénom doit contenir entre 2 et 50 caractères.")]
        public  string FirstName { get; set; }  // Prénom de l'employé

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 50 caractères.")]
        public string LastName { get; set; }  // Nom de l'employé

        [Required]
        public string Position { get; set; }  // Poste de l'employé (ex: "Développeur", "Manager")

        [Required] 
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]// Validation du format de l'email        
        public string Email { get; set; }

        public string Department { get; set; }
        public DateTime DateHired { get; set; }  // Date d'embauche

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Date de création de l'enregistrement

        // Clés étrangères vers les autres entités
        public Guid PositionId { get; set; }  
        public Guid DepartmentId { get; set; }
        public Guid EntrepriseId { get; set; }

        // Propriétés de navigation
        [ForeignKey("PositionId")]
        public Position PositionRef { get; set; }  // Référence à l'entité Position

        [ForeignKey("DepartmentId")]
        public Department DepartmentRef { get; set; }  // Référence à l'entité Department

        [ForeignKey("EntrepriseId")]
        public Entreprise Entreprise { get; set; }
        // Référence à l'entité Entreprise
        public ICollection<Attendance> Attendances { get; set; }  // Liste des présences associées à l'employé

    }
}
