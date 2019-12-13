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
    }
}