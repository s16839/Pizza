using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Models;

namespace Pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly s16839Context _context;

        public PizzasController(s16839Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Metoda zwraca kolekcję dostępnych placków
        /// </summary>
        /// <returns></returns>

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Pizza>>> GetPizza()
        {
            return await _context.Pizza.ToListAsync();
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/Pizzas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Models.Pizza pizza)
        {
            if (id != pizza.IdPizza)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
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

        // POST: api/Pizzas
        [HttpPost]
        public async Task<ActionResult<Models.Pizza>> PostPizza(Models.Pizza pizza)
        {
            _context.Pizza.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizza", new { id = pizza.IdPizza }, pizza);
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Pizza>> DeletePizza(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();

            return pizza;
        }

        [HttpGet("vege")]
        public IActionResult GetVege() {

            var pizzasVege = new List<Models.Pizza>();
            var all = _context.Pizza;
            foreach (var pizza in all) {
                if (pizza.IsVege == true) pizzasVege.Add(pizza);
            }
            return Ok(pizzasVege);
                    
        }

        [HttpGet("vege/{id:int}")]
        public IActionResult GetVege(int id)
        {

            var pizzasVege = new List<Models.Pizza>();
            var all = _context.Pizza;
            foreach (var pizza in all)
            {
                if (pizza.IsVege == true) pizzasVege.Add(pizza);
            }

            
            return Ok(pizzasVege.FirstOrDefault(p => p.IdPizza == id));

        }

        [HttpGet("spicy")]
        public IActionResult GetSpicy()
        {

            var pizzasSpicy = new List<Models.Pizza>();
            var all = _context.Pizza;
            foreach (var pizza in all)
            {
                if (pizza.IsSpicy == true) pizzasSpicy.Add(pizza);
            }
            return Ok(pizzasSpicy);

        }

        [HttpGet("spicy/{id:int}")]
        public IActionResult GetSpicy(int id)
        {

            var pizzasSpicy = new List<Models.Pizza>();
            var all = _context.Pizza;
            foreach (var pizza in all)
            {
                if (pizza.IsSpicy == true) pizzasSpicy.Add(pizza);
            }
            return Ok(pizzasSpicy.FirstOrDefault(p => p.IdPizza == id));

        }


        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.IdPizza == id);
        }
    }
}
