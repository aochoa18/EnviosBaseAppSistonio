using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.CategoriaEstablecimiento
{
    public partial class CategoriaEstablecimientoList : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }

            if (Request.QueryString["Estado"] == "1")
            {
                CambioEstado(int.Parse(Request.QueryString["Id"].ToString()));
            }

            if (!Page.IsPostBack)
            {
                string llave = ConfigurationManager.AppSettings["Usuario"].ToString();
                List<CategoriaEstablecimientoModel> lista = new CategoriaEstablecimientoCliente(llave).GetAll();
                string content = "";
                foreach (CategoriaEstablecimientoModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                         "<td><div class='image-input image-input-empty image-input-outline' id='kt_image_5' >" +
                        "<div class='image-input-wrapper' id='kt_image_load' style=\"background-image: url('" + item.Imagen + "')\"></div></div></td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.Descripcion + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"CategoriaEstablecimientoEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"CategoriaEstablecimientoEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"CategoriaEstablecimientoList.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaEstablecimientoEdit.aspx");
        }

        public void CambioEstado(int id)
        {
            new CategoriaEstablecimientoCliente(llave).CambiarEstadoCategoriaEstablecimiento(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "CategoriaEstablecimientoList.aspx", "success");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }


    }
}
