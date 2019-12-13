using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}