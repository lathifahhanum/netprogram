using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories;
using ProjectClientServer.Repositories.Contract;
using ProjectClientServer.Repositories.Data;
using System.Net;

namespace ProjectClientServer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var results = await _educationRepository.GetAllAsync();
            if (results == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var results = await _educationRepository.GetByIdAsync(id);
            if (results == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Education?>> Insert(Education education)
        {
            var results = await _educationRepository.InsertAsync(education);
            if (results == null)
            {
                return Conflict(new
                {
                    code = StatusCodes.Status409Conflict,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "cannot insert data!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = new
                {
                    message = "Insert success",
                    results
                }
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Education education, int id)
        {
            var results = await _educationRepository.IsExist(id);
            if (!results)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            await _educationRepository.UpdateAsync(education);
            //if (update == 0)
            //{
            //    return Conflict(new
            //    {
            //        code = StatusCodes.Status409Conflict,
            //        status = HttpStatusCode.Conflict.ToString(),
            //        data = new
            //        {
            //            message = "Failed updating data!"
            //        }
            //    });
            //}

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = new
                {
                    message = "Update success",
                    results
                }
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _educationRepository.DeleteAsync(id);
            //if (results == 0)
            //{
            //    return NotFound(new
            //    {
            //        code = StatusCodes.Status404NotFound,
            //        status = HttpStatusCode.NotFound.ToString(),
            //        data = new
            //        {
            //            message = "Data Not Found!"
            //        }
            //    });
            //}

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = new
                {
                    message = "Delete suscess"
                }
            });
        }
    }
}
