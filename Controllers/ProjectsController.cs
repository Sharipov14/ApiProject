using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.IServices;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        IRepositoryWrapper RepoWrapper;
        public ProjectController(IRepositoryWrapper repoWrapper)
        {
            RepoWrapper = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return RepoWrapper.Project.Get();
        }

        [HttpGet("{id}")]
        public Project Get(int id)
        {
            return RepoWrapper.Project.Get(id);
        }

        [HttpPost]
        public IActionResult Post(Project project)
        {
            if (ModelState.IsValid)
            {
                RepoWrapper.Project.Create(project);
                RepoWrapper.Save();

                return Ok(project);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Project project)
        {
            if (ModelState.IsValid)
            {
                RepoWrapper.Project.Update(project);
                RepoWrapper.Save();

                return Ok(project);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteProject = RepoWrapper.Project.Delete(id);
            RepoWrapper.Save();

            return Ok(deleteProject);
        }
    }
}
