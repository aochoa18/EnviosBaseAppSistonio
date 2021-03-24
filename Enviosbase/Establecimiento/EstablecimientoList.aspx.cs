using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Establecimiento
{
    public partial class EstablecimientoList : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }



            if (!Page.IsPostBack)
            {
                List<EstablecimientoModel> lista = new EstablecimientoCliente(llave).GetAll();
                string content = "";
                foreach (EstablecimientoModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.Documento + "</td>" +
                        "<td>" + new CategoriaEstablecimientoCliente(llave).GetById(item.IdCategoria.Value).Nombre + "</td>" +
                        "<td><div class='image-input image-input-empty image-input-outline' id='kt_image_5' >" +
                        "<div class='image-input-wrapper' id='kt_image_load' style=\"background-image: url('" + item.Imagen + "')\"></div></div></td>" +
                        "<td>" + new PaisCliente(llave).GetById(item.IdPais).Nombre + "</td>" +
                        "<td>" + new DepartamentoCliente(llave).GetById(item.IdDepto).Nombre + "</td>" +
                        "<td>" + new MunicipioCliente(llave).GetById(item.IdMunicipio).Nombre + "</td>" +
                        "<td>" + item.Direccion + "</td>" +
                        //"<td>" + item.GeoLat + "</td>" +
                        "<td>" + new ResponsableCliente(llave).GetById(item.IdResponsable).Nombre + "</td>" +
                        "<td>" + item.Telefono + "</td>" +
                        "<td>" + item.Celular + "</td>" +
                        "<td>" + item.Correo + "</td>" +
                        "<td>" + item.HoraInicioLunes + " a " + item.HoraFinLunes + "</td>" +
                        "<td>" + item.HoraInicioMartes + " a " + item.HoraFinMartes + "</td>" +
                        "<td>" + item.HoraInicioMiercoles + " a " + item.HoraFinMiercoles + "</td>" +
                        "<td>" + item.HoraInicioJueves + " a " + item.HoraFinJueves + "</td>" +
                        "<td>" + item.HoraInicioViernes + " a " + item.HoraFinViernes + "</td>" +
                        "<td>" + item.HoraInicioSabado + " a " + item.HoraFinSabado + "</td>" +
                        "<td>" + item.HoraInicioDomingo + " a " + item.HoraFinDomingo + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"EstablecimientoEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"EstablecimientoEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"EstablecimientoEdit.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EstablecimientoEdit.aspx");
        }



        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }

    }
}
