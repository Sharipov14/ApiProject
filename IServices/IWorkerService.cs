using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.IServices
{
    public interface IWorkerService
    {
        IEnumerable<Worker> Get();
        Worker Get(int id);
        IEnumerable<string> GetWorkerFio();
        void Create(Worker worker);
        void Update(Worker worker);
        Worker Delete(int id);
    }
}
