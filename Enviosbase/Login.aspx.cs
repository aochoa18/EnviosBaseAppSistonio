using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Enviosbase
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string LoginUser(string Login, string Password)
        {
            Login log = new Login();
            string json = "";
            try
            {
                respuestaLogin Result = log.BuscaUsuario(Login, Password);
                var jsonSerialiser = new JavaScriptSerializer();
                json = jsonSerialiser.Serialize(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string RecoveryPassword(string correo)
        {
            Login log = new Login();
            string json = "";
            try
            {
                respuestaRecovery Result = log.EnviarCorreoRecovery(correo);
                var jsonSerialiser = new JavaScriptSerializer();
                json = jsonSerialiser.Serialize(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;
        }

        public respuestaLogin BuscaUsuario(string user, string password)
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            respuestaLogin respuesta = new respuestaLogin();
            Session["Conectado"] = "";
            Session["IdUsuario"] = "";
            Session["Usuario"] = "";
            Session["IdTipoUsuario"] = "";
            Session["NombreCompleto"] = "";
            Session["Login"] = null;
            Session["Email"] = null;
            Session["IdEstablecimiento"] = "";

            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(password))
            {
                eCommerceSE.Model.Login userLogin;
                string contrasena = Business.Utils.GetSHA512(password);
                if (user.Contains("@"))
                {
                    userLogin = new LoginCliente(llave).ValidarUsuarioLoginPorCorreoContrasena(user, contrasena);
                }
                else
                {
                    userLogin = new LoginCliente(llave).ValidarUsuarioLoginPorUsuarioContrasena(user, contrasena);
                }

                if (userLogin != null)
                {
                    Session["IdUsuario"] = userLogin.IdUsuario.ToString();
                    Session["IdEstablecimiento"] = userLogin.IdEstablecimiento.ToString();
                    Session["Usuario"] = userLogin.Usuario.ToString();
                    Session["IdTipoUsuario"] = userLogin.IdTipoUsuario.ToString();
                    Session["Nombres"] = userLogin.Nombres.ToString();
                    Session["Apellidos"] = userLogin.Apellidos.ToString();
                    Session["Login"] = user.Trim();
                    Session["FechaIngreso"] = DateTime.Now.ToString();
                    Session["Email"] = userLogin.Email.ToString();
                    respuesta.idRol = int.Parse(userLogin.IdTipoUsuario.ToString());
                    respuesta.idUsuario = int.Parse(userLogin.IdUsuario.ToString());
                }
            }
            return respuesta;
        }

        public respuestaRecovery EnviarCorreoRecovery(string correo)
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            eCommerceSE.Model.Login userLogin;
            userLogin = new LoginCliente(llave).ValidarUsuarioLoginPorCorreo(correo);
            RecoveryPasswordCliente recovery = new RecoveryPasswordCliente(llave);
            RecoveryPasswordModel passwordModel = new RecoveryPasswordModel();
            respuestaRecovery resp = new respuestaRecovery();
            if (userLogin != null)
            {
                DateTime FechaHora = DateTime.Now;
                byte[] time = BitConverter.GetBytes(FechaHora.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
                passwordModel.IdUsuario = userLogin.IdUsuario;
                passwordModel.Token = token;
                passwordModel.FechaCreacion = FechaHora;
                passwordModel.FechaVencimiento = FechaHora.AddHours(24);
                passwordModel.Estado = true;
                recovery.Create(passwordModel);
                Business.EmailBussines emailBussines = new Business.EmailBussines();
                string path = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
                emailBussines.SendMailRecovery(passwordModel, userLogin, path);
                resp.result = 1;
            }
            else
            {
                resp.result = 0;
            }
            return resp;
        }

    }

    public class respuestaLogin
    {
        public int idRol { get; set; }
        public int idUsuario { get; set; }
    }

    public class respuestaRecovery
    {
        public int result { get; set; }
    }
}