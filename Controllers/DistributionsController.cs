using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using ApiProject.IServices;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistributionsController : Controller
    {
        IRepositoryWrapper RepoWrapper;
        public DistributionsController(IRepositoryWrapper repoWrapper)
        {
            RepoWrapper = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<Distribution> Get()
        {
            return RepoWrapper.Distribution.Get();
        }

        [HttpGet("{id}")]
        public Distribution Get(int id)
        {
            return RepoWrapper.Distribution.Get(id);
        }

        [HttpPost]
        public IActionResult Post(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                RepoWrapper.Distribution.Create(distribution);
                RepoWrapper.Save();

                return Ok(distribution);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                RepoWrapper.Distribution.Update(distribution);
                RepoWrapper.Save();

                return Ok(distribution);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedDistributions = RepoWrapper.Distribution.Delete(id);
            RepoWrapper.Save();

            return Ok(deletedDistributions);
        }
    }
}
