using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TicTacToe.Models.db;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly TicTacContext _context;

        public GamesController(TicTacContext context)
        {
            _context = context;
        }

        // GET: api/Games/"name"
        [HttpGet()]
        public async Task<ActionResult<Game>> GetGame(string name)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Name == name);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutGame(int id, string LustMove, int fieldNumber)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (id != game.Id)
            {
                return BadRequest();
            }

            game.CountOfMoves++;
            game.LustMove = LustMove;

            switch (fieldNumber)
            {
                case 1:
                    game._1 = LustMove;
                    break;
                case 2:
                    game._2 = LustMove;
                    break;
                case 3:
                    game._3 = LustMove;
                    break;
                case 4:
                    game._4 = LustMove;
                    break;
                case 5:
                    game._5 = LustMove;
                    break;
                case 6:
                    game._6 = LustMove;
                    break;
                case 7:
                    game._7 = LustMove;
                    break;
                case 8:
                    game._8 = LustMove;
                    break;
                case 9:
                    game._9 = LustMove;
                    break;
            }

            if (game.CountOfMoves >= 5)
                StatusGame.status_check(game);

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(string name)
        {
            Game game = new Game(name);

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
