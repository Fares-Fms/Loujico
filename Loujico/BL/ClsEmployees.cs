using Loujico.Models;
using Microsoft.EntityFrameworkCore;
namespace Loujico.BL
{
    public interface IEmployees
    {
        public List<TbEmployee> GetAllEmployees();
        public TbEmployee GetEmployeeById(int id);
        public bool AddEmp(TbEmployee employee);
        public bool Delete(int id);
    }
    public class ClsEmployees: IEmployees
    {

        CompanySystemContext CTX;
        public ClsEmployees(CompanySystemContext companySystemContext)
        {

            CTX = companySystemContext;

        }
        public List<TbEmployee> GetAllEmployees()
        {
            try
            {
                var lstEmployees = CTX.TbEmployees.Where(e => !e.IsDeleted).ToList();
                return lstEmployees;
            }
            catch
            { 
                return new List<TbEmployee>();
            }
        }
        public bool AddEmp(TbEmployee employee)
        {

            try
            {
                employee.CreatedAt = DateTime.Now;
                employee.IsPresent = true;
                CTX.TbEmployees.Add(employee);                
                CTX.SaveChanges(); 
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var employee = CTX.TbEmployees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                    return false;
                employee.IsDeleted = true;
                CTX.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        public TbEmployee GetEmployeeById(int id)
     {
           return CTX.TbEmployees
                    .Include(e => e.TbProjectsEmployees)  
                    .Include(e => e.TbProductsEmployees)  
                    .FirstOrDefault(e => e.Id == id);
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
