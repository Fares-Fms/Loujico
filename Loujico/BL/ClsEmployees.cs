using Loujico.Models;
namespace Loujico.BL
{
    public class ClsEmployees
    {
        CompanySystemContext CTX;
        public ClsEmployees(CompanySystemContext companySystemContext)
        {

            CTX = companySystemContext;

        }
        public bool addEmp(TbEmployee employee)
        {
            try
            {
                CTX.TbEmployees.Add(employee);
            return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
