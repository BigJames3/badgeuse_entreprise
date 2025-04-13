using API_Pointage.DbContext;
using API_Pointage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Pointage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PositionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Position
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            return await _context.Positions.ToListAsync();  // Récupérer toutes les positions
        }

        // GET: api/Position/5
        [HttpGet("{PositionId}")]
        public async Task<ActionResult<Position>> GetPosition(Guid PositionId)
        {
            var position = await _context.Positions.FindAsync(PositionId); // Trouver une position par ID

            if (position == null)
            {
                return NotFound();  // Retourner une erreur 404 si la position n'existe pas
            }

            return position;  // Retourner la position trouvée
        }

        // POST: api/Position
        [HttpPost]
        public async Task<ActionResult<Position>> PostPosition([FromBody] Position position)
        {
            _context.Positions.Add(position);  // Ajouter une nouvelle position
            await _context.SaveChangesAsync();  // Sauvegarder dans la base de données

            return CreatedAtAction(nameof(GetPosition), new { PositionId = position.PositionId }, position);  // Retourner l'ID de la position créée
        }

        // PUT: api/Position/5
        [HttpPut("{PositionId}")]
        public async Task<IActionResult> PutPosition(Guid PositionId, [FromBody] Position updatedPosition)
        {
            if (PositionId != updatedPosition.PositionId)
            {
                return BadRequest();  // Si l'ID ne correspond pas, retourner une erreur 400
            }

            _context.Entry(updatedPosition).State = EntityState.Modified;  // Marquer l'entité comme modifiée

            try
            {
                await _context.SaveChangesAsync();  // Sauvegarder les modifications
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Positions.Any(e => e.PositionId == PositionId))
                {
                    return NotFound();  // Si la position n'existe pas, retourner une erreur 404
                }
                else
                {
                    throw;
                }
            }

            return NoContent();  // Retourner un statut 204 NoContent si tout s'est bien passé
        }

        // DELETE: api/Position/5
        [HttpDelete("{PositionId}")]
        public async Task<IActionResult> DeletePosition(Guid PositionId)
        {
            var position = await _context.Positions.FindAsync(PositionId);  // Trouver la position à supprimer

            if (position == null)
            {
                return NotFound();  // Si la position n'existe pas, retourner une erreur 404
            }

            _context.Positions.Remove(position);  // Supprimer la position
            await _context.SaveChangesAsync();  // Sauvegarder la suppression dans la base de données

            return NoContent();  // Retourner un statut 204 NoContent après suppression
        }
    }
}
