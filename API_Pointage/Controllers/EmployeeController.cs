using API_Pointage.DbContext;
using API_Pointage.Helpers;
using API_Pointage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Pointage.Helpers;

namespace API_Pointage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ApplicationDbContext context, ILogger<EmployeesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // 1. Ajouter un nouvel employé
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee employee)
        {
            // Vérifie si l'email existe déjà dans la base
            if (await _context.Employees.AnyAsync(e => e.Email == employee.Email))
            {
                return BadRequest(new
                {
                    Code = ErrorCodes.EmailAlreadyExists,
                    Message = "Un employé avec cet email existe déjà."
                });
            }

            // Vérification de l'ID envoyé par le client
            if (employee.EmployeeId == Guid.Empty)
            {
                employee.EmployeeId = Guid.NewGuid(); // Génère un GUID si aucun ID n'est fourni
            }

            // Vérifie que les données nécessaires sont présentes
            if (string.IsNullOrWhiteSpace(employee.FirstName) || string.IsNullOrWhiteSpace(employee.LastName))
            {
                return BadRequest(new
                {
                    Code = ErrorCodes.MissingFields,
                    Message = "Le prénom et le nom sont obligatoires."
                });
            }

            employee.CreatedAt = DateTime.UtcNow; // Ajoute la date actuelle
            _context.Employees.Add(employee);     // Ajoute l'employé
            await _context.SaveChangesAsync();    // Enregistre

            return CreatedAtAction(nameof(GetEmployee), new { employeeId = employee.EmployeeId }, employee);
        }


        // 2. Récupérer la liste des employés
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync(); // Récupérer tous les employés de la base de données
            return Ok(employees);
        }

        // 3. Récupérer un employé par EmployeeId
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId); // Trouver un employé par son ID
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // 4. Mettre à jour un employé
        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, [FromBody] Employee updatedEmployee)
        {
            // Vérifier si l'employé existe dans la base de données
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return NotFound(); // Si l'employé n'existe pas, retourner un 404
            }

            // Validation des données envoyées (par exemple vérifier que le prénom et nom sont renseignés)
            if (string.IsNullOrWhiteSpace(updatedEmployee.FirstName) || string.IsNullOrWhiteSpace(updatedEmployee.LastName))
            {
                return BadRequest("Le prénom et le nom sont obligatoires."); // Si manquent, retourner une erreur
            }

            // Mettre à jour les informations de l'employé
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Position = updatedEmployee.Position;
            employee.Email = updatedEmployee.Email;
            employee.Department = updatedEmployee.Department; // Ajouter cette ligne si tu veux aussi mettre à jour le département

            // Mettre à jour l'état de l'entité dans le DbContext
            _context.Entry(employee).State = EntityState.Modified;

            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content - Mise à jour réussie
        }


        // 5. Supprimer un employé
        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                    return NotFound();

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }
    }
}