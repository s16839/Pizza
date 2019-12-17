using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.Models;

namespace Pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private s16839Context _context;

        public PizzasController(s16839Context context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas() {

            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id) {

            var pizza = _context.Pizza.FirstOrDefault(p => p.IdPizza == id);
            if (pizza == null) return NotFound();
            else return Ok(pizza);
        }

        [HttpGet("/spicy")]
        public IActionResult GetSpicyPizzas() {
            return Ok(_context.Pizza.Where(p => p.IsSpicy == true).ToList());
        }

        [HttpGet("{id:int}/ingredients")]
        public IActionResult GetPizzaIngredients(int id) {

           var pizza = _context.Pizza.FirstOrDefault(p => p.IdPizza == id).IngredientSet.ToList();
            if (pizza == null) return NotFound();
            else return Ok(pizza);
        }
    }
}