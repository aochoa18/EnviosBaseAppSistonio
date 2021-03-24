using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace Enviosbase
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string ConsultarListaPaises()
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            try
            {
                string json = "";
                PaisCliente objetoClass = new PaisCliente(llave);
                List<PaisModel> Result = objetoClass.GetAll();
                var jsonSerialiser = new JavaScriptSerializer();
                json = jsonSerialiser.Serialize(Result);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string ConsultarListaDepartamentosByPais(int idPais)
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            try
            {
                string json = "";
                DepartamentoCliente objetoClass = new DepartamentoCliente(llave);
                List<DepartamentoModel> Result = objetoClass.GetByPais(idPais);
                var jsonSerialiser = new JavaScriptSerializer();
                json = jsonSerialiser.Serialize(Result);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string ConsultarListaMunicipioByDepto(int idDepto)
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            try
            {
                string json = "";
                MunicipioCliente objetoClass = new MunicipioCliente(llave);
                List<MunicipioModel> Result = objetoClass.GetByDepartamento(idDepto);
                var jsonSerialiser = new JavaScriptSerializer();
                json = jsonSerialiser.Serialize(Result);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}