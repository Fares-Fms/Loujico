using Loujico.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Loujico.BL.ClsEmployees;

namespace Loujico.BL
{
    public interface IProject {
        public TbProject GetById(int id);
        public List<TbProject> Pagintion(int id);
        public Task<bool> Add(TbProject project);
        public Task<bool> Delete(int id);
    
    }

    public class ClsProject : IProject 
    {
        CompanySystemContext CTX;
        const int pageSize = 10;
        public ClsProject(CompanySystemContext companySystemContext)
        {

            CTX = companySystemContext;

        }
        public TbProject GetById(int id)
        {
         
            TbProject project = CTX.TbProjects.Find(id);
            if (project == null)
            {
                return new TbProject();
            }
            return project;
        }
            public List<TbProject> Pagintion(int id)
        {
            try
            {
               


                var LstCars = CTX.TbProjects.Where(a => a.IsDeleted != true).Skip((id - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();


                return LstCars;
            }

            catch
            {
                return new List<TbProject>();
            }
        }
        public async Task< bool> Add(TbProject project)
        {

            try
            {
                
                project.CreatedAt = DateTime.Now;
                CTX.TbProjects.AddAsync(project);
                CTX.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {

            try
            {
                TbProject project = CTX.TbProjects.Find(id);
                if (project == null)
                    return false;
                project.UpdatedAt = DateTime.Now;
                project.IsDeleted=true;
                CTX.Entry(project).State = EntityState.Modified;
                CTX.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    
    }
}
