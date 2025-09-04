using Loujico.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace Loujico.BL
{

    public interface IProject {
<<<<<<< HEAD
        public TbProject GetById(int id);
        public Task<TbProject> GetById(int id);
        public Task<List<TbProject>> Pagintion(int id);
        public Task<bool> Add(TbProject project);
        public Task<bool> Delete(int id);
=======
    public interface IProject
    {
        public Task<TbProject> GetByIdAsync(int id);
        public Task<List<TbProject>> PagintionAsync(int id);
        public Task<bool> AddAsync(TbProject project);
        public Task<bool> DeleteAsync(int id);
>>>>>>> backupoub
=======
        public Task <TbProject> GetById(int id);
        public Task<List<TbProject>> Pagintion(int id);
        public Task<bool> Add(TbProject project);
        public Task<bool> Delete(int id);


>>>>>>> 2e291428f487f8faef5eb387dfcdbc10a3b32d1e
    }
    public class ClsProject : IProject
    {
        CompanySystemContext CTX;
        const int pageSize = 10;

        public ClsProject(CompanySystemContext companySystemContext)
        {
            CTX = companySystemContext;
        }

        public async Task<TbProject> GetById(int id)
        {
            var project = await CTX.TbProjects.FindAsync(id);
            if (project == null)
            {
                return new TbProject();
            }
            return project;
        }

        public async Task<List<TbProject>> Pagintion(int id)
        {
            try
            {
                var LstCars = await CTX.TbProjects
                                       .Where(a => a.IsDeleted != true)
                                       .Skip((id - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

        public async Task< bool> Add(TbProject project)
        {
            catch
            {
                return new List<TbProject>();
            }

<<<<<<< HEAD
              await  CTX.TbProjects.AddAsync(project);
               await  CTX.SaveChangesAsync();

=======
>>>>>>> backupoub

            try
            {
                project.CreatedAt = DateTime.Now;
<<<<<<< HEAD

        public async Task<bool> Delete(int id)
        {
                await CTX.TbProjects.AddAsync(project);
                await CTX.SaveChangesAsync();
>>>>>>> backupoub
                return true;
            }
            catch
            {
                return false;
            }
        }
<<<<<<< HEAD
        public async Task<bool> Delete(int id)
        {
=======
>>>>>>> backupoub

            try
            {
                var project = await CTX.TbProjects.FindAsync(id);
                if (project == null)
=======
        public async Task<bool> Add(TbProject project)
        {

                try
                {
                    project.CreatedAt = DateTime.Now;
                    CTX.TbProjects.AddAsync(project);
                    CTX.SaveChangesAsync();

                await CTX.TbProjects.AddAsync(project);
                await CTX.SaveChangesAsync();

                    return true;
                }
                catch
                {
>>>>>>> 2e291428f487f8faef5eb387dfcdbc10a3b32d1e
                    return false;
                }
            }

            public async Task<bool> Delete(int id)
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