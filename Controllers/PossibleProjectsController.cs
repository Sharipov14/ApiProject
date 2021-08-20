using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;

using ApiProject.IServices;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PossibleProjectsController : Controller
    {
        IRepositoryWrapper RepoWapper;
        public PossibleProjectsController(IRepositoryWrapper repoWapper)
        {
            RepoWapper = repoWapper;
        }

        [HttpGet]
        public IEnumerable<PossibleProject> Get()
        {
            return RepoWapper.PossibleProject.Get();
        }

        [HttpGet("{id}")]
        public PossibleProject Get(int id)
        {
            return RepoWapper.PossibleProject.Get(id);
        }

        [HttpPost]
        public IActionResult Post(PossibleProject possibleProject)
        {
            if (ModelState.IsValid)
            {
                RepoWapper.PossibleProject.Create(possibleProject);
                RepoWapper.Save();

                return Ok(possibleProject);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(PossibleProject possibleProject)
        {
            if (ModelState.IsValid)
            {
                RepoWapper.PossibleProject.Update(possibleProject);
                RepoWapper.Save();

                return Ok(possibleProject);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedPossibleProject = RepoWapper.PossibleProject.Delete(id);
            RepoWapper.Save();

            return Ok(deletedPossibleProject);
        }
    }
}
