using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Pointage.Models
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PositionId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le poste doit contenir entre 2 et 50 caractères.")]
        public required string PositionName { get; set; }
    }
}
