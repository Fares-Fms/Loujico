using Loujico.Models;
using Microsoft.EntityFrameworkCore;
namespace Loujico.BL
{
    public interface IEmployees
    {
        public Task<List<TbEmployee>> GetAllEmployeesAsync(int id);
        public Task<TbEmployee> GetEmployeeByIdAsync(int id);
        public Task<bool> AddEmpAsync(TbEmployee employee);
        public Task<bool> DeleteAsync(int id);
    }

    public class ClsEmployees : IEmployees
    {
        CompanySystemContext CTX;
        const int pageSize = 10;
        public ClsEmployees(CompanySystemContext companySystemContext)
        {
            CTX = companySystemContext;
        }

        public async Task<List<TbEmployee>> GetAllEmployeesAsync(int id)
        {
            try
            {
                var lstEmployees = await CTX.TbEmployees
                                            .Where(e => !e.IsDeleted).Skip((id - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToListAsync();
                return lstEmployees;
            }
            catch
            {
                return new List<TbEmployee>();
            }
        }

        public async Task<bool> AddEmpAsync(TbEmployee employee)
        {
            try
            {
                employee.CreatedAt = DateTime.Now;
                employee.IsPresent = true;
                await CTX.TbEmployees.AddAsync(employee);
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
                var employee = await CTX.TbEmployees.FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null)
                    return false;

                employee.IsDeleted = true;
                await CTX.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TbEmployee> GetEmployeeByIdAsync(int id)
        {
            return await CTX.TbEmployees
                            .Include(e => e.TbProjectsEmployees)
                            .Include(e => e.TbProductsEmployees)
                            .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}


/* ==================== Edit Employee ====================
   تعديل بيانات موظف موجود
   لازم تعطيه ID الموظف والبيانات الجديدة
========================================================= */
//    public bool EditEmp(TbEmployee employee)
//    {
//     try
//     {
//        var existing = CTX.TbEmployees.FirstOrDefault(e => e.Id == employee.Id);
//        if (existing == null) return false;

//                existing.FirstName = employee.FirstName;
//        existing.LastName = employee.LastName;
//        existing.Phone = employee.Phone;
//        existing.Email = employee.Email;
//        existing.EmployeesAddress = employee.EmployeesAddress;
//        existing.Position = employee.Position;
//        existing.Age = employee.Age;
//        existing.ProfileImage = employee.ProfileImage;
//        existing.IsPresent = employee.IsPresent;
//        existing.EmployeesDescription = employee.EmployeesDescription;
//        existing.ServiceDuration = employee.ServiceDuration;
//        existing.Salary = employee.Salary;
//        existing.UpdatedAt = DateTime.UtcNow;

//        CTX.SaveChanges(); // حفظ التغييرات
//        return true;
//        }
//        catch
//        {
//        return false;
//        }
//}
