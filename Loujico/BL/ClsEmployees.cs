using Loujico.Models;
using Microsoft.EntityFrameworkCore;
namespace Loujico.BL
{
    public class ClsEmployees
    {
        public interface IEmployees
        {
            public List<TbEmployee> GetAllEmployees();
           
            public TbEmployee GetEmployeeById(int id);
            //public VwItem GetItemId(int id);
            //public bool Save(TbItem item);
            public bool Delete(int id);

        }
        CompanySystemContext CTX;
        public ClsEmployees(CompanySystemContext companySystemContext)
        {

            CTX = companySystemContext;

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
        public bool DeleteEmp(int id)
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
        public List<TbEmployee> GetAllEmployees()
        {     
            return CTX.TbEmployees.ToList();        
        }
        public TbEmployee? GetEmployeeById(int id)
     {
           return CTX.TbEmployees
                    .Include(e => e.TbProjectsEmployees)  
                    .Include(e => e.TbProductsEmployees)  
                    .FirstOrDefault(e => e.Id == id);
       }

    }
}

//using Loujico.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Loujico.BL
//{
//    public class ClsEmployees
//    {
//        private readonly CompanySystemContext CTX;

//        public ClsEmployees(CompanySystemContext companySystemContext)
//        {
//            CTX = companySystemContext;
//        }

        /* ==================== Add New Employee ====================
           تضيف موظف جديد للجدول TbEmployees
           ترجع true إذا تمت الإضافة، false إذا صار خطأ
        ============================================================ */
        //public bool AddEmp(TbEmployee employee)
        //{
        //    try
        //    {
        //        CTX.TbEmployees.Add(employee);
        //        CTX.SaveChanges(); // حفظ التغييرات
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        /* ==================== Edit Employee ====================
           تعديل بيانات موظف موجود
           لازم تعطيه ID الموظف والبيانات الجديدة
        ========================================================= */
        //public bool EditEmp(TbEmployee employee)
        //{
        //    try
        //    {
        //        var existing = CTX.TbEmployees.FirstOrDefault(e => e.Id == employee.Id);
        //        if (existing == null) return false;

        //        // تحديث الحقول
        //        existing.FirstName = employee.FirstName;
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
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        /* ==================== Delete Employee ====================
           حذف موظف عن طريق ID
           إذا الموظف غير موجود بيرجع false
        ========================================================= */
        //public bool DeleteEmp(int id)
        //{
        //    try
        //    {
        //        var employee = CTX.TbEmployees.FirstOrDefault(e => e.Id == id);
        //        if (employee == null) 
        //    return false;

        //        CTX.TbEmployees.Remove(employee);
        //        CTX.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        /* ==================== Get All Employees ====================
           جلب كل الموظفين من الجدول
        ============================================================ */
//        public List<TbEmployee> GetAllEmployees()
//        {
//            return CTX.TbEmployees.ToList();
//        }

//        /* ==================== Get Employee By ID ====================
//           جلب موظف واحد عن طريق الـ ID
//           إذا مو موجود بيرجع null
//        ============================================================ */
//        public TbEmployee? GetEmployeeById(int id)
//        {
//            return CTX.TbEmployees
//                     .Include(e => e.TbProjectsEmployees)  // تجيب المشاريع تبعو
//                     .Include(e => e.TbProductsEmployees)  // تجيب المنتجات تبعو
//                     .FirstOrDefault(e => e.Id == id);
//        }
//    }
//}
