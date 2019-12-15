using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza_v1.Models;

namespace Pizza_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladnikisController : ControllerBase
    {
        private s15480Context _context;
        public SkladnikisController(s15480Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetSkladnikis()
        {
            return Ok(_context.Skladniki.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetSkladniki(int id)
        {
            var skladniki = _context.Skladniki.FirstOrDefault(e => e.IdSkladniki == id);
            if (skladniki == null)
            {
                return NotFound();
            }

            return Ok(skladniki);
        }

        [HttpPost]
        public IActionResult Create(Skladniki newSkladniki)
        {

            _context.Skladniki.Add(newSkladniki);
            _context.SaveChanges();

            return StatusCode(201, newSkladniki); //201, 202
        }

        [HttpPut("{IdSkladniki:int}")]
        public IActionResult Update(int IdSkladniki, Skladniki updateSkladniki)
        {
            

            if (_context.Skladniki.Count(e => e.IdSkladniki == IdSkladniki) == 0)
            {
                return NotFound();
            }

            _context.Skladniki.Attach(updateSkladniki);
            _context.Entry(updateSkladniki).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updateSkladniki);

        }

        [HttpDelete("{IdSkladniki:int}")]
        public IActionResult Delete(int IdSkladniki)
        {
            var sklad = _context.Skladniki.FirstOrDefault(e => e.IdSkladniki == IdSkladniki);
            if (sklad == null)
            {
                return NotFound();
            }

            _context.Skladniki.Remove(sklad);
            _context.SaveChanges();

            return Ok(sklad);
        }
    }
}