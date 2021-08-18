using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.IServices
{
    interface IDestributionService
    {
        IEnumerable<Distribution> Get();
        Distribution Get(int id);
        void Create(Distribution project);
        void Update(Distribution project);
        Distribution Delete(int id);
    }
}
