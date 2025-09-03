using Loujico.BL;
using Loujico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loujico.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        CompanySystemContext CTX;
        IEmployees ClsEmployees;
        public EmpController(CompanySystemContext cTX, IEmployees clsEmployees)
        {

            CTX = cTX;
            ClsEmployees = clsEmployees;
        }
        [HttpPost("AddEmp")]
        public async Task<ActionResult<ApiResponse<string>>> AddEmp([FromForm] TbEmployee emp)
        {
            
                if (!ModelState.IsValid)
                {

                    return Ok(new ApiResponse<String> {
                        Data="wronge",
                        Message= "wronge"

                    });
                     
                }
            try
            {
                CTX.TbEmployees.Add(emp);
                await CTX.SaveChangesAsync();
                return Ok(new ApiResponse<String>
                {
                    Data = "Done",
                    Message = "Done"

                });
            }
            catch 
            {
                return Ok(new ApiResponse<String>
                {
                    Data = "wronge",
                    Message = "wronge"

                });
            }
        }
        [HttpDelete("GetAllEmployees")]
        public async Task<ActionResult<ApiResponse<List<TbEmployee>>>> GetAllEmployees()
        {
            try
            {

                return Ok(new ApiResponse<List<TbEmployee>>
                {
                    Data = ClsEmployees.GetAllEmployees()
                });
            }
            catch
            {
                return Ok(new ApiResponse<List<TbEmployee>>
                {
                    Message="Error"
                });

            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            try
            {
                ClsEmployees.Delete(id);
                return Ok(new ApiResponse<String>
                {
                    Data = "done"
                });
            }
            catch 
            {
                return Ok(new ApiResponse<String>
                {
                    Data = "Error"
                });
                
            }
        }
    }
}