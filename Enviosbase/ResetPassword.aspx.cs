using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace Enviosbase
{

    public partial class ResetPassword : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["token"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                string token = Request.QueryString["token"];
                RecoveryPasswordCliente passwordBusiness = new RecoveryPasswordCliente(llave);
                RecoveryPasswordModel passModel = passwordBusiness.GetByToken(token);
                if (passModel == null)
                {

                }
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string RecoveryPassword(string password, string token)
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            RecoveryPasswordCliente passwordBusiness = new RecoveryPasswordCliente(llave);
            RecoveryPasswordModel passModel = passwordBusiness.GetByToken(token);
            respuestaRecoveryToken resp = new respuestaRecoveryToken();
            if (passModel == null)
            {
                resp.status = 0;
                resp.mensaje = "El Token ingresado no es valido";
            }
            else
            {
                if (passModel.FechaVencimiento < DateTime.Now)
                {
                    resp.status = 0;
                    resp.mensaje = "El Token ingresado se encuentra vencido";
                    passModel.Estado = false;
                    passwordBusiness.Update(passModel);
                }
                else if (passModel.Estado == false)
                {
                    resp.status = 0;
                    resp.mensaje = "El Token ingresado no es valido";
                }
                if (passModel.Estado == true)
                {
                    ResetPassword log = new ResetPassword();
                    resp = log.CambiarContrasena(passModel, password);
                    passModel.Estado = false;
                    passwordBusiness.Update(passModel);
                }
            }
            var jsonSerialiser = new JavaScriptSerializer();
            string json = jsonSerialiser.Serialize(resp);
            return json;
        }

        public respuestaRecoveryToken CambiarContrasena(RecoveryPasswordModel passModel, string password)
        {
            UsuarioCliente usuarioBusiness = new UsuarioCliente(llave);
            UsuarioModel usuario = usuarioBusiness.GetById(passModel.IdUsuario.Value);
            usuario.PasswordLogin = Business.Utils.GetSHA512(password);
            usuarioBusiness.CambioClave(usuario);
            respuestaRecoveryToken resp = new respuestaRecoveryToken();
            resp.status = 1;
            resp.mensaje = "Contraseña actualiada correctamente";
            return resp;
        }
    }

    public class respuestaRecoveryToken
    {
        public int status { get; set; }
        public string mensaje { get; set; }
    }
}