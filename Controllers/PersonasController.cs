using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectosolicitud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace proyectosolicitud.Controllers
{
    [Route("api/[controller]")]
    public class PersonasController : Controller
    {
        private solicitudespersonasContext _context;
        public PersonasController(solicitudespersonasContext contex)
        {
            _context = contex;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> Get()
        {
            return await _context.Personas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var resultado = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Persona persona)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
                    }
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return Created(nameof(Get),new { id=persona.Id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Persona persona)
        {
            try
            {
                if (persona.Id == id)
                {
                    _context.Entry(persona).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Created(nameof(Get), new { id = persona.Id });


                }
                else
                {
                    return BadRequest();
                }
            
            
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            //var resultado = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            //if (resultado == null) {
            //    return NotFound();
            //}
            //_context.Entry(persona).State= EntityState.Modified;

            //await _context.SaveChangesAsync();
            //return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }
            _context.Personas.Remove(resultado); 
            return NoContent();
        }



    }
    
}
