using Microsoft.AspNetCore.Mvc;

namespace gestion_emplois_pointages.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Exemple de liste d'employés avec GUID
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = Guid.NewGuid(), LastName = "Dupont", FirstName = "Jean", Position = "Technicien" },
            new Employee { EmployeeId = Guid.NewGuid(), LastName = "Leclerc", FirstName = "Marie", Position = "Chef de projet" }
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return employees;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(Guid id) // Utilisation de GUID comme type d'identifiant
        {
            var employee = employees.Find(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid(); // Génération automatique d'un GUID
            employee.CreatedAt = DateTime.UtcNow; // Enregistrement de la date actuelle
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }
    }

    public class Employee
    {
        public Guid EmployeeId { get; set; } // Utilisation de GUID comme clé primaire
        public string FirstName { get; set; } // Prénom
        public string LastName { get; set; } // Nom
        public string Position { get; set; } // Poste
        public DateTime CreatedAt { get; set; } // Date de création de l'enregistrement
    }
}
