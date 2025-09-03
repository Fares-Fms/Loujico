using Loujico.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace Loujico.BL
{
    public interface IProject
    {
        public Task<TbProject> GetByIdAsync(int id);
        public Task<List<TbProject>> PagintionAsync(int id);
        public Task<bool> AddAsync(TbProject project);
        public Task<bool> DeleteAsync(int id);
    }

    public class ClsProject : IProject
    {
        CompanySystemContext CTX;
        const int pageSize = 10;

        public ClsProject(CompanySystemContext companySystemContext)
        {
            CTX = companySystemContext;
        }

        public async Task<TbProject> GetByIdAsync(int id)
        {
            var project = await CTX.TbProjects.FindAsync(id);
            if (project == null)
            {
                return new TbProject();
            }
            return project;
        }

        public async Task<List<TbProject>> PagintionAsync(int id)
        {
            try
            {
                var LstCars = await CTX.TbProjects
                                       .Where(a => a.IsDeleted != true)
                                       .Skip((id - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

                return LstCars;
            }
            catch
            {
                return new List<TbProject>();
            }
        }

        public async Task<bool> AddAsync(TbProject project)
        {
            try
            {
                project.CreatedAt = DateTime.Now;
                await CTX.TbProjects.AddAsync(project);
                await CTX.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var project = await CTX.TbProjects.FindAsync(id);
                if (project == null)
                    return false;

                project.UpdatedAt = DateTime.Now;
                project.IsDeleted = true;
                CTX.Entry(project).State = EntityState.Modified;
                await CTX.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}