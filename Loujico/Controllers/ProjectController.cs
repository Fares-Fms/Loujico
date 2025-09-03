using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Loujico.Models;
using Loujico.BL;

namespace Loujico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProject ClsProject;
        CompanySystemContext CTX;
        public ProjectController(IProject clsProject, CompanySystemContext context)
        {

            ClsProject = clsProject;
            CTX = context;

        }
        [HttpPost("Add")]
        public async Task<ActionResult<ApiResponse<string>>> Add([FromForm] TbProject proj)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return Ok(new ApiResponse<String>
                    {
                        Data = "wronge",
                        Message = "wronge"

                    });

                }
                return Ok(proj);
            }
            catch (Exception ex)
            {
                return Ok(proj);
            }
        }
    }
}
