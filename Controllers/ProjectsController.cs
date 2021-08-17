using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        ApplicationContext db;
        public ProjectsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return db.Projects.ToList();
        }

        [HttpGet("{id}")]
        public Project Get(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ProjectId == id);
            return project;
        }

        [HttpPost]
        public IActionResult Post(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return Ok(project);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Update(project);
                db.SaveChanges();
                return Ok(project);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ProjectId == id);
            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
            }
            return Ok(project);
        }
    }
}
