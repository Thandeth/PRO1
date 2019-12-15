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
    public class ZamowieniesController : ControllerBase
    {
        private s15480Context _context;
        public ZamowieniesController(s15480Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetZamowienies()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetZamowienie(int id)
        {
            var zamowienia = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return Ok(zamowienia);
        }

        [HttpPost]
        public IActionResult Create(Zamowienie newZamowienie)
        {

            _context.Zamowienie.Add(newZamowienie);
            _context.SaveChanges();

            return StatusCode(201, newZamowienie);
        }

        [HttpPut("{IdZamowienie}")]
        public IActionResult Update(int IdZamowienie, Zamowienie updateZamowienie)
        {

            if (_context.Zamowienie.Count(e => e.IdZamowienie == IdZamowienie) == 0)
            {
                return NotFound();
            }

            _context.Zamowienie.Attach(updateZamowienie);
            _context.Entry(updateZamowienie).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updateZamowienie);
        }
        
        [HttpDelete("{IdZamowienie:int}")]
        public IActionResult Delete(int IdZamowienie)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (zamowienie == null)
            {
                return NotFound();
            }

            _context.Zamowienie.Remove(zamowienie);
            _context.SaveChanges();

            return Ok(zamowienie);
        }
    }
}