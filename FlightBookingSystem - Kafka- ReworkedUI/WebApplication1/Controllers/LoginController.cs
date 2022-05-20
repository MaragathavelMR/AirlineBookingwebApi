using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System;
using System.Collections.Generic;

namespace AdminUserLoginService.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerRepository _iJWTManager;
        public LoginController(IJWTManagerRepository iJWTManager)
        {
            _iJWTManager = iJWTManager;   
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Userlogin")]
        public IActionResult Authenticate(TblUserdetail userdata)
        {
            try
            {
                List<string> result = _iJWTManager.Login(userdata);

                if (result.Count == 0)
                {
                    return Unauthorized("Incorrect Email Id/ Password");
                }

                var token = _iJWTManager.Authenticate(userdata);

                if (token == null)
                {
                    return Unauthorized();
                }

                Dictionary<string, string> lst = new Dictionary<string, string>();

                lst.Add("userId", result[0].ToString());
                lst.Add("roleId", result[1].ToString());
                lst.Add("token", token.Token);
                lst.Add("refreshToken", token.RefreshToken);

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult RegisterUser(TblUserdetail userdata)
        {

            try
            {
                int IsRegisteredSuccessfully = _iJWTManager.RegisterUser(userdata);

                if (IsRegisteredSuccessfully > 0)
                {
                    return Ok(new { response = "User Registered successfully" });
                }
                else
                {
                    return BadRequest(new { response = "User could not be registered" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }
    }
}
