using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectosolicitud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace proyectosolicitud.Controllers
{  
    [Route("api/[controller]")]
    public class SolicitudController : Controller
    {
      
        
            private solicitudespersonasContext _context;
            public SolicitudController(solicitudespersonasContext contex)
            {
                _context = contex;

            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Solicitud>>> Get()
            {
                
            
                return await _context.Solicituds.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult> Get(int id)
            {
            var resultado = await _context.Solicituds.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(resultado);
            }

            [HttpPost]
            public async Task<ActionResult> Post([FromBody] Solicitud solicitud)
            {
            if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _context.Solicituds.Add(solicitud);
                await _context.SaveChangesAsync();
                return CreatedAtRoute(nameof(Get), new { id = solicitud.Id }, solicitud);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> Put(int id, [FromBody] Solicitud solicitud)
            {
            try
            {
                if (solicitud.Id == id)
                {
                    _context.Entry(solicitud).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Created(nameof(Get), new { id = solicitud.Id });


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
           
        }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
            try
            {
                var solicitud = _context.Solicituds.FirstOrDefault(x => x.Id == id);

                if (solicitud != null)
                {
                    _context.Solicituds.Remove(solicitud);
                    _context.SaveChangesAsync();
                    return Ok(id);


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

            //    var resultado = await _context.Solicituds.FirstOrDefaultAsync(x => x.Id == id);
            //    if (resultado == null)
            //    {
            //        return NotFound();
            //    }
            //    _context.Solicituds.Remove(resultado);
            //    await _context.SaveChangesAsync();
            //    return NoContent();
        }



        

    }
}
