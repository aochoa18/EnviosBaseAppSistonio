using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Marca
{
    public partial class MarcaList : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }

            if (Request.QueryString["Estado"] == "1")
            {
                CambioEstado(int.Parse(Request.QueryString["Id"].ToString()));
            }

            if (!Page.IsPostBack)
            {
                MarcaCliente business = new MarcaCliente(llave);
                List<MarcaModel> lista = business.GetAll();
                string content = "";
                foreach (MarcaModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"MarcaEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"MarcaEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"MarcaList.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcaEdit.aspx");
        }

        public void CambioEstado(int id)
        {
            new MarcaCliente(llave).CambiarEstadoMarca(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "MarcaList.aspx", "success");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }
    }
}
