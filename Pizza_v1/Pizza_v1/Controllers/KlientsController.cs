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
    public class KlientsController : ControllerBase
    {
        private s15480Context _context;
        public KlientsController(s15480Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetKlients()
        {
            return Ok(_context.Klient.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetKlient(int id)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdKlient == id);
            if (klient == null)
            {
                return NotFound();
            }

            return Ok(klient);
        }

        [HttpPost]
        public IActionResult Create(Klient newKlient)
        {

            _context.Klient.Add(newKlient);
            _context.SaveChanges();

            return StatusCode(201, newKlient); //201, 202
        }

        [HttpPut("{IdKlient:int}")]
        public IActionResult Update(int IdKlient, Klient updateKlient)
        {
            if (_context.Klient.Count(e => e.IdKlient == IdKlient) == 0)
            {
                return NotFound();
            }
            _context.Klient.Attach(updateKlient);
            _context.Entry(updateKlient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updateKlient);
        }

        [HttpDelete("{IdKlient:int}")]
        public IActionResult Delete(int IdKlient)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdKlient == IdKlient);
            if (klient == null)
            {
                return NotFound();
            }

            _context.Klient.Remove(klient);
            _context.SaveChanges();

            return Ok(klient);
        }
    }
}