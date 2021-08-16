using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;
using ApiProject.Models.Report;

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
