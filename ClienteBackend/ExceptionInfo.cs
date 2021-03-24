using System;
using System.Runtime.Serialization;
using System.ServiceModel.Web;

namespace ClienteBackend
{
    /// <summary>
    /// Clase que contine la información de las excepciones
    /// </summary>
    [DataContractAttribute]
    public class ExceptionInfo
    {

        #region Campos
        /// <summary>
        /// Codigo del error
        /// </summary>
        private string errorCode;


        /// <summary>
        /// Descripción del error
        /// </summary>
        private String descripcion;

        /// <summary>
        /// Fecha en la que se produció el error
        /// </summary>
        private DateTime fecha;

        #endregion

        #region Propiedades

        /// <summary>
        /// Codigo del error
        /// </summary>
        [DataMemberAttribute]
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }
        /// <summary>
        /// Descripción del error
        /// </summary>
        [DataMemberAttribute]
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Fecha en la que se produció el error
        /// </summary>
        [DataMemberAttribute]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Url que se invoca
        /// </summary>
        [DataMemberAttribute]
        public string Url
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Crea una excepción
        /// </summary>
        /// <param name="_code">Codigo de error</param>
        /// <param name="_descripcion">Descripción del error.</param>
        /// <param name="url">Url que generó el error.</param>
        public ExceptionInfo(string _code, string _descripcion, string url)
            : this(_code, _descripcion)
        {
            Url = url;
        }

        /// <summary>
        /// Crea una excepcion por codido y descripcion
        /// </summary>
        /// <param name="_code">codigo de la excepcion</param>
        /// <param name="_descripcion">descipcion de la excepcion</param>
        public ExceptionInfo(string _code, string _descripcion)
        {
            ErrorCode = _code;
            Descripcion = _descripcion;
            Fecha = DateTime.Now;
        }

        #endregion

        #region ToString

        /// <summary>
        /// Convierte en estring compuesto la excepcion
        /// </summary>
        /// <returns>Retorna la excepcion en cadena</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2: yyyy-MM-dd hh:mm:ss} {3}", ErrorCode, Descripcion, Fecha, Url);
        }

        #endregion

        #region Throw

        /// <summary>
        /// Lanza una excepción de tipo especifico para ser utilizado por los clientes.
        /// </summary>
        public void Throw()
        {
            throw new WebFaultException<ExceptionInfo>(this, System.Net.HttpStatusCode.PartialContent);
        }
        #endregion
    }
}
