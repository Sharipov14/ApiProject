using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.IServices
{
    interface IReportService
    {
        IEnumerable<Report> Get();
        Report Get(int id);
        void Create(Report report);
        void Update(Report report);
        Report Delete(int id);
    }
}
