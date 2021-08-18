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
    public class PossibleProjectController : Controller
    {
        ApplicationContext db;

        public PossibleProjectController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<PossibleProject> Get()
        {
            var d = db.PossibleProjects.Include(d => d.Project).Include(b => b.Worker).ToList();

            foreach (var l in d)
            {
                l.ProjectName = l.Project.ProjectName;
                l.WorkerFio = l.Worker.WorkerFio;
            }

            return d;
        }

        [HttpGet("{id}")]
        public PossibleProject Get(int id)
        {
            PossibleProject possibleProject = db.PossibleProjects.Include(p => p.Project).Include(w => w.Worker).FirstOrDefault(x => x.Id == id);
            possibleProject.ProjectName = possibleProject.Project.ProjectName;
            possibleProject.WorkerFio = possibleProject.Worker.WorkerFio;
            return possibleProject;
        }

        [HttpPost]
        public IActionResult Post(PossibleProject possibleProject)
        {
            if (ModelState.IsValid)
            {
                var project = db.Projects.FirstOrDefault(x => x.ProjectName == possibleProject.ProjectName);
                var worker = db.Workers.FirstOrDefault(x => x.WorkerFio == possibleProject.WorkerFio);
                possibleProject.ProjectId = project.ProjectId;
                possibleProject.WorkerId = worker.WorkerId;
                db.PossibleProjects.Add(possibleProject);
                db.SaveChanges();
                return Ok(possibleProject);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(PossibleProject possibleProject)
        {
            if (ModelState.IsValid)
            {
                var project = db.Projects.FirstOrDefault(x => x.ProjectName == possibleProject.ProjectName);
                var worker = db.Workers.FirstOrDefault(x => x.WorkerFio == possibleProject.WorkerFio);
                possibleProject.ProjectId = project.ProjectId;
                possibleProject.WorkerId = worker.WorkerId;
                db.PossibleProjects.Update(possibleProject);
                db.SaveChanges();
                return Ok(possibleProject);
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
