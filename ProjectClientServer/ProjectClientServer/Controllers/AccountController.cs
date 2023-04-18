using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;
using ProjectClientServer.Models;
using ProjectClientServer.Repositories;
using ProjectClientServer.Repositories.Contract;
using ProjectClientServer.ViewModel;
using System.Net;

namespace ProjectClientServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            var login = await _accountRepository.LoginAsync(loginVM);
            if (login)
            {
                return Ok("Login success");
            }
            else { return BadRequest("Login gagal"); }

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                await _accountRepository.RegisterAsync(registerVM);
                return Ok("registrasi success");
            }
            catch
            {
                return BadRequest("registrasi gagal");
            }

            //return register is null ? NotFound(new { status = HttpStatusCode.NotFound, message = "register gagal." }) 
            //  : Ok(new {status = HttpStatusCode.OK, message = "register berhasil." });

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var results = await _accountRepository.GetAllAsync();
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

        [HttpGet("{nik}")]
        public async Task<ActionResult> GetById(string nik)
        {
            var results = await _accountRepository.GetByIdAsync(nik);
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

        [HttpPost]
        public async Task<ActionResult<Account?>> Insert(Account account)
        {
            var results = await _accountRepository.InsertAsync(account);
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

        [HttpPut]
        public async Task<ActionResult> Update(Account account)
        {
            var results = await _accountRepository.UpdateAsync(account);
            if (results == 0)
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
                data = new
                {
                    message = "Update success",
                    results
                }
            });
        }

        [HttpDelete("{nik}")]
        public async Task<ActionResult> Delete(string nik)
        {
            var results = await _accountRepository.DeleteAsync(nik);
            if (results == 0)
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
                data = new
                {
                    message = "Delete suscess"
                }
            });
        }

    }
}
