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
            var klient = _context.Klient.FirstOrDefault(e => e.IdSkladniki == id);
            if (klient == null)
            {
                return NotFound();
            }

            return Ok(klient);
        }
    }
}