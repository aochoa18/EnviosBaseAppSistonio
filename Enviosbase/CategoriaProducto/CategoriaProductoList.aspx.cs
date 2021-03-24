using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.CategoriaProducto
{
    public partial class CategoriaProductoList : System.Web.UI.Page
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
                List<CategoriaProductoModel> lista = new CategoriaProductoCliente(llave).GetAll();
                string content = "";
                foreach (CategoriaProductoModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.id + "</td>" +
                         "<td><div class='image-input image-input-empty image-input-outline' id='kt_image_5' >" +
                        "<div class='image-input-wrapper' id='kt_image_load' style=\"background-image: url('" + item.Imagen + "')\"></div></div></td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"CategoriaProductoEdit.aspx?View=0&Id=" + item.id + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-md-12\"><a href=\"CategoriaProductoEdit.aspx?View=1&Id=" + item.id + "\"><i class=\"fa fa-edit\"></i> editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"CategoriaProductoEdit.aspx?View=1&Estado=1&Id=" + item.id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaProductoEdit.aspx");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }

    }
}
