using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFunnyPlace.Models;
namespace WebApiFunnyPlace.DataAccess.User
{
    public class UserDataAccess
    {
        public  static IEnumerable<UcatalogoSexo> ObtenerCatalogoSexo()
        {
            try
            {
                IEnumerable<UcatalogoSexo> lstXeso = new List<UcatalogoSexo>();
                using (FunnyPlaceBetaContext context = new FunnyPlaceBetaContext())
                {
                    lstXeso = context.UcatalogoSexo.ToList();
                }
                return lstXeso;                
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }

        internal static bool registrarUsuario(UserRegister u)
        {
            try
            {
                using (FunnyPlaceBetaContext context = new FunnyPlaceBetaContext())
                {
                    context.Add<UserRegister>(u);
                    context.SaveChanges();                    
                    return true;
                }
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }

        internal static object restrarUsuarioAuth(UserOauthRegister userAuth)
        {
            try
            {
                using (FunnyPlaceBetaContext context = new FunnyPlaceBetaContext())
                {
                    context.Add<UserOauthRegister>(userAuth);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }

        internal static bool loginUser(LoginGeneric log)
        {
            try
            {
                using (FunnyPlaceBetaContext context = new FunnyPlaceBetaContext())
                {
                   var result = context.UserRegister.Where(c=> c.Email == log.email && c.Password == log.password).FirstOrDefault();
                    if (result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception _exc)
            {
                throw _exc;
            }
        }
    }
}
