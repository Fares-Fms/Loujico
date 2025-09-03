using Loujico.Models;
using Microsoft.EntityFrameworkCore;
namespace Loujico.BL
{
    public interface ICustomers
    {
        public List<TbCustomer> GetAllCustomers();
        public TbCustomer GetCustomerById(int id);
        public bool AddCustomer(TbCustomer customer);
        public bool Delete(int id);
    }

    public class ClsCustomers : ICustomers
    {
        CompanySystemContext CTX;

        public ClsCustomers(CompanySystemContext companySystemContext)
        {
            CTX = companySystemContext;
        }

        public List<TbCustomer> GetAllCustomers()
        {
            try
            {
                return CTX.TbCustomers.Where(x => !x.IsDeleted).ToList();
            }
            catch
            {
                return new List<TbCustomer>();
            }
        }

        public TbCustomer GetCustomerById(int id)
        {
            return CTX.TbCustomers
                      .Include(c => c.TbCustomersProducts)
                      .Include(c => c.TbProjects)
                      .Include(c => c.TbInvoices)
                      .FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }
        public bool AddCustomer(TbCustomer customer)
        {
            try
            {
                customer.CreatedAt = DateTime.UtcNow;
                customer.IsDeleted = false;
                CTX.TbCustomers.Add(customer);
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
                var customer = CTX.TbCustomers.FirstOrDefault(c => c.Id == id);
                if (customer == null)
                    return false;

                customer.IsDeleted = true;
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
