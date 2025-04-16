using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API_Pointage.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; } // GUID généré automatiquement //  Utilisation de GUID comme clé primaire

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le prénom doit contenir entre 2 et 50 caractères.")]
        public required string FirstName { get; set; }  // Prénom de l'employé

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 50 caractères.")]
        public required string LastName { get; set; }  // Nom de l'employé

        [Required]
        public required string Position { get; set; }  // Poste de l'employé (ex: "Développeur", "Manager")

        [Required] 
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]// Validation du format de l'email        
        public required string Email { get; set; }

        public required string Department { get; set; }
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

        //public ICollection<LeaveRequest> LeaveRequests { get; set; }  // Liste des demandes de congé associées à l'employé
        //public ICollection<OvertimeRequest> OvertimeRequests { get; set; }  // Liste des demandes d'heures supplémentaires associées à l'employé
        //public ICollection<Salary> Salaries { get; set; }  // Liste des salaires associés à l'employé
        //public ICollection<Notification> Notifications { get; set; }  // Liste des notifications associées à l'employé
        //public ICollection<Entreprise> Entreprises { get; set; }  // Liste des entreprises associées à l'employé

    }
}
