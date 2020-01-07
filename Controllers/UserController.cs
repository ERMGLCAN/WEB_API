using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiFunnyPlace.Models;
using WebApiFunnyPlace.DataAccess.User;

namespace WebApiFunnyPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("ObtenerCatalogoSexo")]
        public ActionResult<IEnumerable<UcatalogoSexo>> ObtenerCatalogoSexo()
        {
            try
            {
                var result = UserDataAccess.ObtenerCatalogoSexo();
                return Ok(result);
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }

        [HttpPost("registrarUsuario")]
        public ActionResult RegistrarUsuario([FromBody]UserRegister user)
        {
            try
            {
                 var result = UserDataAccess.registrarUsuario(user);
                 return Ok(result);                
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }

        [HttpPost("restrarUsuarioAuth")]
        public ActionResult restrarUsuarioAuth([FromBody]UserOauthRegister userAuth)
        {
            try
            {
                var result = UserDataAccess.restrarUsuarioAuth(userAuth);
                return Ok(result);
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }

        [HttpPost("loginUser")]
        public ActionResult loginUser([FromBody]LoginGeneric log)
        {
            try
            {
                var result = UserDataAccess.loginUser(log);
                return Ok(result);
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }
    }
}
