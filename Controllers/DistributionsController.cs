using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

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
            /* Worker worker = new Worker { WorkerFio = "ФИО1", WorkerPosition = "Разработчик1" };
             Worker worker2 = new Worker { WorkerFio = "ФИО2", WorkerPosition = "Разработчик2" };
             Distribution distribution1 = new Distribution { ProjectId = 1, Worker = worker, DateStart = DateTime.Parse("5 / 1 / 2020 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture), Hours = 4 };
             Distribution distribution2 = new Distribution { ProjectId = 1, Worker = worker2, DateStart = DateTime.Parse("5 / 3 / 2020 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture), Hours = 1 };
             Distribution distribution3 = new Distribution { ProjectId = 1, Worker = worker, DateStart = DateTime.Parse("5 / 2 / 2020 8:30:52 AM", System.Globalization.CultureInfo.InvariantCulture), Hours = 6 };

             db.Workers.AddRange(worker, worker2);
             db.Distributions.AddRange(distribution1, distribution2, distribution3);
             db.SaveChanges();*/

            //IEnumerable<Distribution> distrbs = db.Distributions.Include(u => u.Worker).Include(d => d.Project).ToList();

            /*foreach (var distrib in distrbs)
            {
                string workerName = distrib.Worker?.WorkerFio;
            }*/
            return db.Distributions.Include(u => u.Worker).Include(d => d.Project).ToList();
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
