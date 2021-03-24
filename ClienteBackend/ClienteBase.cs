using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace ClienteBackend
{
    public abstract class ClienteBase
    {
        string UrlServices = ConfigurationManager.AppSettings["UrlBackEnd"];

        public ModelRespuesta ConsumirPorPost(string accion, Dictionary<string, object> paramsUrs, object paramBody)
        {
            HttpWebRequest request = WebRequest.CreateHttp(ConstruirParametrosUrl(accion, paramsUrs));
            request.Method = "POST";
            request.ContentType = @"application/x-www-form-urlencoded";

            ConstruirBody(paramBody, ref request);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            ModelRespuesta resultado;
            Stream dataStream;
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                resultado = JsonConvert.DeserializeObject<ModelRespuesta>(responseFromServer);
            }
            response.Close();

            return resultado;
        }

        private string ConstruirParametrosUrl(string accion, Dictionary<string, object> parametros)
        {
            StringBuilder sb = new StringBuilder();
            if (parametros != null)
                foreach (var parametro in parametros)
                    sb.AppendFormat("{0}={1}&", parametro.Key, HttpUtility.UrlEncode(string.Format("{0}", parametro.Value)));

            return string.Format("{0}/{1}?{2}", UrlServices, accion, sb);
        }

        /// <summary>
        /// Contruye el cuerpo de la petición con el parámetro si es necesario. Además invoca la petición y maneja el error en caso de existir.
        /// </summary>
        /// <param name="parametro">objeto a enviar en el cuerpo del request.</param>
        /// <param name="request">Request a enviar.</param>
        /// <param name="asyncResult">Contexto Asincrono.</param>
        private void ConstruirBody(object parametro, ref HttpWebRequest request, IAsyncResult asyncResult = null)
        {
            string body = string.Empty;
            if (parametro == null)
            {
                request.ContentLength = 0;
                return;
            }

            var properties = from p in parametro.GetType().GetProperties()
                             where p.GetValue(parametro, null) != null
                             select p.Name + "=" + (p.GetValue(parametro, null).ToString());

            // queryString will be set to "Id=1&State=26&Prefix=f&Index=oo"                  
            string queryString = String.Join("&", properties.ToArray());

            byte[] byteArray = Encoding.UTF8.GetBytes(queryString);
            request.ContentLength = byteArray.Length;

            try
            {
                Stream netStream = request.GetRequestStream();
                netStream.Write(byteArray, 0, byteArray.Length);
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.ConnectFailure)
                {
                    var message = string.Format("El servicio {0} no puede ser enlazado", request.RequestUri);
                    //throw new InvalidOperationException(message, wex);
                    //Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(wex));
                    LanzarExcepcionPorDefecto("002", message, request.RequestUri.ToString());
                }
            }
        }

        /// <summary>
        /// Lanza la excepción por defecto.
        /// </summary>
        /// <param name="codigo">Códgo de la excepción</param>
        /// <param name="mensaje">Mensaje de la excepción</param>
        /// <param name="url">url a la que se intentó realizar la petición.</param>
        internal static void LanzarExcepcionPorDefecto(string codigo = "002 ", string mensaje = "Error interno del servicio", string url = null)
        {
            var message = string.Format("{0} '{1}'", mensaje, url);
            var ex = new WebFaultException<ExceptionInfo>(new ExceptionInfo(codigo, mensaje, url), HttpStatusCode.PartialContent);
            throw ex;
        }
    }
}
