using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Domiciliario
{
    public partial class DomiciliarioList : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            //comprobarCOntrasena();

            if (Session["usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }



            if (Request.QueryString["Notificacion"] == "1")
            {
                EnviarUsuarioContraseña(int.Parse(Request.QueryString["Id"].ToString()));
            }

            if (!Page.IsPostBack)
            {
                List<DomiciliarioModel> lista = new DomiciliarioCliente(llave).GetAll();
                string content = "";
                foreach (DomiciliarioModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                         "<td><div class='image-input image-input-empty image-input-outline' id='kt_image_5' >" +
                        "<div class='image-input-wrapper' id='kt_image_load' style=\"background-image: url('" + item.Foto + "')\"></div></div></td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.Documento + "</td>" +
                        "<td>" + new PaisCliente(llave).GetById(item.IdPais).Nombre + "</td>" +
                        "<td>" + new DepartamentoCliente(llave).GetById(item.IdDepto).Nombre + "</td>" +
                        "<td>" + new MunicipioCliente(llave).GetById(item.IdMunicipio).Nombre + "</td>" +
                        "<td>" + item.Direccion + "</td>" +
                        "<td>" + item.Correo + "</td>" +
                        "<td>" + item.Telefono + "</td>" +
                        "<td>" + item.Celular + "</td>" +
                        "<td>" + new TipoVehiculoCliente(llave).GetById(item.IdTipoVehiculo).Nombre + "</td>" +
                        "<td>" + new MarcaCliente(llave).GetById(item.IdMarca).Nombre + "</td>" +
                        "<td>" + item.Modelo + "</td>" +
                        "<td>" + item.Placa + "</td>" +
                         "<td><span class=\"col-md-12\"><a href=\"" + item.ImagenDocumento + "\" target =\"_blank\"><i class=\"fa fa-download\"></i> Descargar </a></span></td>" +
                         "<td><span class=\"col-md-12\"><a href=\"" + item.ImagenPase + "\" target =\"_blank\"><i class=\"fa fa-download\"></i> Descargar </a></span></td>" +
                         "<td><span class=\"col-md-12\"><a href=\"" + item.ImagenSoat + "\" target =\"_blank\"><i class=\"fa fa-download\"></i> Descargar </a></span></td>" +
                         "<td><span class=\"col-md-12\"><a href=\"" + item.ImagenTarjetaPropiedad + "\" target =\"_blank\"><i class=\"fa fa-download\"></i> Descargar </a></span></td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"DomiciliarioEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"DomiciliarioEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"DomiciliarioEdit.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"DomiciliarioEdit.aspx?Notificacion=1&Id=" + item.Id + "\"><i class=\"fa fa-user\"></i> Recordar usuario </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("DomiciliarioEdit.aspx");
        }



        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }

        public void EnviarUsuarioContraseña(int idDomiciliario)
        {
            DomiciliarioCliente usuarioBusiness = new DomiciliarioCliente(llave);

            DomiciliarioModel model = new DomiciliarioCliente(llave).GetById(idDomiciliario);

            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            model.PasswordLogin = RationalSWUtils.Criptography.CreateMD5(token);
            usuarioBusiness.Update(model);

            new Business.EmailBussines().SendMailRememberUserDom(model.Documento, token, model.Nombre, model.Correo);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "Se ha enviado el correo de notificación a " + model.Correo, "DomiciliarioList.aspx", "success");

        }

        public void comprobarCOntrasena()
        {
            string token = "8133310";
            string hash = RationalSWUtils.Criptography.CreateMD5(token);
            string respuesta = hash;
        }



    }
}
