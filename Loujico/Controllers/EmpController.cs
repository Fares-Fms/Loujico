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
        public EmpController(CompanySystemContext cTX)
        {

            CTX = cTX;

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
        [HttpDelete("DeleteEmp")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteEmp(int id)
        {

        }
    }
}