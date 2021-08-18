using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using System.Threading.Tasks;
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
            var d = db.Distributions.Include(d => d.Project).Include(b => b.Worker).ToList();

            foreach (var l in d)
            {
                l.ProjectName = l.Project.ProjectName;
                l.WorkerFio = l.Worker.WorkerFio;
            }

            return d;
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Distribution>>> GetDistributions()
        {
            //var worker = db.Workers.ToList();
            //IEnumerable<Distribution> distributions =  db.Distributions.ToList();
            var d = db.Distributions.ToListAsync();

            foreach (var l in d)
            {

            }

            return await db.Distributions.ToListAsync();
        }*/

        [HttpGet("{id}")]
        public Distribution Get(int id)
        {
            Distribution distribution = db.Distributions.Include(p => p.Project).Include(w => w.Worker).FirstOrDefault(x => x.Id == id);
            distribution.ProjectName = distribution.Project.ProjectName;
            distribution.WorkerFio = distribution.Worker.WorkerFio;
            return distribution;
        }

        [HttpPost]
        public IActionResult Post(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                var project = db.Projects.FirstOrDefault(x => x.ProjectName == distribution.ProjectName);
                var worker = db.Workers.FirstOrDefault(x => x.WorkerFio == distribution.WorkerFio);
                distribution.ProjectId = project.ProjectId;
                distribution.WorkerId = worker.WorkerId;
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
                var project = db.Projects.FirstOrDefault(x => x.ProjectName == distribution.ProjectName);
                var worker = db.Workers.FirstOrDefault(x => x.WorkerFio == distribution.WorkerFio);
                distribution.ProjectId = project.ProjectId;
                distribution.WorkerId = worker.WorkerId;
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
