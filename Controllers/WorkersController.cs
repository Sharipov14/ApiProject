using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.IServices;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : Controller
    {
        IRepositoryWrapper RepoWrapper;
        public WorkersController(IRepositoryWrapper repoWrapper)
        {
            RepoWrapper = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return RepoWrapper.Worker.Get();
        }

        [HttpGet("{id}")]
        public Worker Get(int id)
        {
            return RepoWrapper.Worker.Get(id);
        }

        [HttpPost]
        public IActionResult Post(Worker worker)
        {
            if (ModelState.IsValid)
            {
                RepoWrapper.Worker.Create(worker);
                RepoWrapper.Save();

                return Ok(worker);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Worker worker)
        {
            if (ModelState.IsValid)
            {
                RepoWrapper.Worker.Update(worker);
                RepoWrapper.Save();

                return Ok(worker);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteWorker = RepoWrapper.Worker.Delete(id);
            RepoWrapper.Save();

            return Ok(deleteWorker);
        }
    }
}
