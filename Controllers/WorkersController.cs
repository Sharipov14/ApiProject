using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;
using ApiProject.Models.Workers;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : Controller
    {
        ApplicationContext db;
        public WorkersController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return db.Workers.ToList();
        }

        [HttpGet("{id}")]
        public Worker Get(int id)
        {
            Worker worker = db.Workers.FirstOrDefault(x => x.WorkerId == id);
            return worker;
        }

        [HttpPost]
        public IActionResult Post(Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return Ok(worker);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Update(worker);
                db.SaveChanges();
                return Ok(worker);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Worker worker = db.Workers.FirstOrDefault(x => x.WorkerId == id);
            if (worker != null)
            {
                db.Workers.Remove(worker);
                db.SaveChanges();
            }
            return Ok(worker);
        }
    }
}
