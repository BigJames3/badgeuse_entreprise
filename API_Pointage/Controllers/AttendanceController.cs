﻿using API_Pointage.DbContext;
using API_Pointage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pointage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Injection du DbContext
        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Ajouter un enregistrement de pointage (check-in)
        [HttpPost("checkin/{employeeId}")]
        public async Task<ActionResult<Attendance>> CheckIn(Guid employeeId)
        {
            // Vérifier si l'employé existe
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
                return NotFound("Employé introuvable.");

            // Vérifier si un check-in a déjà été effectué aujourd'hui
            var existingAttendance = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId && a.Date == DateTime.Today)
                .FirstOrDefaultAsync();

            if (existingAttendance != null)
                return BadRequest("Un pointage d'arrivée a déjà été effectué pour aujourd'hui.");

            var attendance = new Attendance
            {
                AttendanceId = Guid.NewGuid(),
                EmployeeId = employeeId,
                CheckInTime = DateTime.Now,
                Date = DateTime.Today
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Pointage d'arrivée enregistré avec succès.", Data = attendance });
        }

        // 2. Ajouter un enregistrement de sortie (check-out)
        [HttpPost("checkout/{employeeId}")]
        public async Task<ActionResult<Attendance>> CheckOut(Guid employeeId)
        {
            // Vérifier si l'employé existe
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
                return NotFound("Employé introuvable.");

            // Trouver un enregistrement de pointage en cours
            var attendance = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId && a.CheckOutTime == null && a.Date == DateTime.Today)
                .FirstOrDefaultAsync();

            if (attendance == null)
                return NotFound("Aucun pointage d'arrivée trouvé pour aujourd'hui.");

            // Vérifier la cohérence de l'heure de sortie
            if (attendance.CheckInTime >= DateTime.Now)
                return BadRequest("L'heure de sortie ne peut pas être antérieure ou égale à l'heure d'entrée.");

            attendance.CheckOutTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Pointage de sortie enregistré avec succès.", Data = attendance });
        }
         
        // 3. Récupérer la présence d'un employé
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendance(Guid employeeId, DateTime? startDate, DateTime? endDate)
        {
            // Vérifier si l'employé existe
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
                return NotFound("Employé introuvable.");

            // Construire la requête avec des filtres optionnels
            var query = _context.Attendances.Where(a => a.EmployeeId == employeeId);

            if (startDate.HasValue)
                query = query.Where(a => a.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(a => a.Date <= endDate.Value);

            var attendances = await query.ToListAsync();

            if (!attendances.Any())
                return NotFound("Aucune présence trouvée pour cet employé.");

            return Ok(new { Message = "Présences récupérées avec succès.", Data = attendances });
        }
    }
}

