using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Producto
{
    public partial class ProductoList : System.Web.UI.Page
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
                ProductoCliente business = new ProductoCliente(llave);
                List<ProductoModel> lista = business.GetByEstablecimiento(int.Parse(Session["IdEstablecimiento"].ToString()));
                string content = "";
                foreach (ProductoModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.Descripcion + "</td>" +
                        "<td>" + item.Presentacion + "</td>" +
                        "<td>" + item.Precio + "</td>" +
                        "<td><div class='image-input image-input-empty image-input-outline' id='kt_image_5' >" +
                        "<div class='image-input-wrapper' id='kt_image_load' style=\"background-image: url('" + item.Imagen + "')\"></div></div></td>" +
                        "<td>" + new CategoriaProductoCliente(llave).GetById(item.IdCategoria.Value).Nombre + "</td>" +
                        "<td>" + item.CodigoSKU + "</td>" +
                        "<td>" + new EstablecimientoCliente(llave).GetById(item.IdEstablecimiento.Value).Nombre + "</td>" +
                        "<td>" + item.PrecioPromocion + "</td>" +
                        "<td>" + item.PorcentajePromocion + "</td>" +
                        "<td>" + item.Codigo + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"ProductoEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"ProductoEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"ProductoList.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductoEdit.aspx");
        }

        protected void btnMasivos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductoMasivo.aspx");
        }

        public void CambioEstado(int id)
        {
            new ProductoCliente(llave).CambiarEstadoProducto(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "ProductoList.aspx", "success");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }

    }
}
