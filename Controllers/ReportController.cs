using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController
    {
        ApplicationContext db;
        public ReportController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return db.Report.ToList();
        }
    }
}
