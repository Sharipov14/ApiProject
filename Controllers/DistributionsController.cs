using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;


namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributionsController : Controller
    {
        ApplicationContext db;
        public DistributionsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Distribution> Get()
        {
            return db.Distributions.ToList();
        }

        [HttpGet("{id}")]
        public Distribution Get(int id)
        {
            Distribution distribution = db.Distributions.FirstOrDefault(x => x.Id == id);
            return distribution;
        }

        [HttpPost]
        public IActionResult Post(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                db.Distributions.Add(distribution);
                db.SaveChanges();
                return Ok(distribution);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                db.Update(distribution);
                db.SaveChanges();
                return Ok(distribution);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Distribution distribution = db.Distributions.FirstOrDefault(x => x.Id == id);
            if (distribution != null)
            {
                db.Distributions.Remove(distribution);
                db.SaveChanges();
            }
            return Ok(distribution);
        }
    }
}
