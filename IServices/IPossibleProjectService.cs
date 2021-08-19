using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.IServices
{
    public interface IPossibleProjectService
    {
        IEnumerable<PossibleProject> Get();
        PossibleProject Get(int id);
        void Create(PossibleProject prossibleProject);
        void Update(PossibleProject prossibleProject);
        PossibleProject Delete(int id);
    }
}
