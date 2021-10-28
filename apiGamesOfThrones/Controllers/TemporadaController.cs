using apiGamesOfThrones.Context;
using apiGamesOfThrones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGamesOfThrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadaController : ControllerBase
    {

        private readonly AppDbContext context; 
        public TemporadaController(AppDbContext context)
        {
            this.context = context;

        }
        // GET: api/<TemporadaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Temporada.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);            }
        }

        // GET api/<TemporadaController>/5
        [HttpGet("{id}",Name ="GetTemporada")]
        public ActionResult Get(int id)
        {
            try
            {
                var temporada = context.Temporada.FirstOrDefault(t => t.id == id);
                return Ok(temporada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<TemporadaController>
        [HttpPost]
        public ActionResult Post([FromBody] Temporada temporada)
        {
            try
            {
                context.Temporada.Add(temporada);
                context.SaveChanges();
                return CreatedAtRoute("GetTemporada",new { id = temporada.id }, temporada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TemporadaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Temporada temporada)
        {
            try
            {
                if(temporada.id == id)
                {
                    context.Entry(temporada).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTemporada", new { id = temporada.id }, temporada);
                    ;
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

        // DELETE api/<TemporadaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var temporada = context.Temporada.FirstOrDefault(t => t.id == id);
                if(temporada != null)
                {
                    context.Temporada.Remove(temporada);
                    context.SaveChanges();
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
        }
    }
}
