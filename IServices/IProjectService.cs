using ApiProject.Models;
using System.Collections.Generic;

namespace ApiProject.IServices
{
    public interface IProjectService
    {
        IEnumerable<Project> Get();
        Project Get(int id);
        IEnumerable<string> GetProjectName();
        void Create(Project project);
        void Update(Project project);
        Project Delete(int id);
    }
}
