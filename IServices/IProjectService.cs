using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.IServices
{
    interface IProjectService
    {
        IEnumerable<Project> Get();
        Project Get(int id);
        void Create(Project project);
        void Update(Project project);
        Project Delete(int id);
    }
}
