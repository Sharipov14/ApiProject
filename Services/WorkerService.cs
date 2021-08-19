using ApiProject.IServices;
using ApiProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject.Services
{
    public class WorkerService : IWorkerService
    {
        private ApplicationContext Context;

        public WorkerService(ApplicationContext context)
        {
            Context = context;
        }

        public IEnumerable<Worker> Get()
        {
            return Context.Workers.ToList();
        }
        public Worker Get(int id)
        {
            Worker worker = Context.Workers.FirstOrDefault(x => x.WorkerId == id);
            return worker;
        }
        public void Create(Worker worker)
        {
            Context.Workers.Add(worker);
        }
        public void Update(Worker worker)
        {
            Context.Workers.Update(worker);
        }
        public Worker Delete(int id)
        {
            Worker worker = Get(id);

            if (worker != null)
            {
                Context.Workers.Remove(worker);
            }
            return worker;
        }
    }
}
