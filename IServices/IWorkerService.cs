using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.IServices
{
    interface IWorkerService
    {
        IEnumerable<Worker> Get();
        Worker Get(int id);
        void Create(Worker worker);
        void Update(Worker worker);
        Worker Delete(int id);
    }
}
