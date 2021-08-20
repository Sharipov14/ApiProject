using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.IServices;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        IRepositoryWrapper RepoWrapper;
        public ProjectsController(IRepositoryWrapper repoWrapper)
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

        [HttpGet("projectName")]
        public IEnumerable<string> GetProjectName()
        {
            return RepoWrapper.Project.GetProjectName();
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
            var deletedProject = RepoWrapper.Project.Delete(id);
            RepoWrapper.Save();

            return Ok(deletedProject);
        }
    }
}
