﻿using API_Pointage.DbContext;
using API_Pointage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pointage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Injection du DbContext
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 2. Récupérer la liste des Departments
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            var departments = await _context.Departments.ToListAsync(); // Récupérer tous les Departments de la base de données
            return Ok(departments);
        }

        // GET api/<DepartmentController>/5 / Récupérer un Department par DepartmentId
        [HttpGet("{DepartmentId}")]
        public async Task<ActionResult<Department>> GetDepartment(Guid DepartmentId)
        {
            var department = await _context.Departments.FindAsync(DepartmentId); // Trouver un département par son ID
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] Department department)
        {
            // Ajoute le département à la base de données
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            // Retourne le département créé avec son ID
            return CreatedAtAction(nameof(GetDepartment), new { DepartmentId = department.DepartmentId }, department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{DepartmentId}")]
        public async Task<IActionResult> UpdateDepartment(Guid DepartmentId, [FromBody] Department updatedDepartment)
        {
            // Trouve le département à mettre à jour
            var department = await _context.Departments.FindAsync(DepartmentId);

            if (department == null)
            {
                // Si le département n'existe pas, retourne une erreur 404
                return NotFound();
            }

            // Met à jour les propriétés du département
            department.DepartmentName = updatedDepartment.DepartmentName;

            // Sauvegarde les modifications dans la base de données
            await _context.SaveChangesAsync();

            // Retourne un statut 204 NoContent pour indiquer que l'opération a réussi
            return NoContent();
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{DepartmentId}")]
        public async Task<IActionResult> Delete(Guid DepartmentId)
        {
            // Trouve le département à supprimer
            var department = await _context.Departments.FindAsync(DepartmentId);

            if (department == null)
            {
                // Si le département n'existe pas, retourne une erreur 404
                return NotFound();
            }

            // Supprime le département
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            // Retourne un statut 204 NoContent pour indiquer que l'opération a réussi
            return NoContent();
        }
    }
}
