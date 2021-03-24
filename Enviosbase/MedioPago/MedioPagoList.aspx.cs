using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.MedioPago
{
    public partial class MedioPagoList : System.Web.UI.Page
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
                MedioPagoCliente business = new MedioPagoCliente(llave);
                List<MedioPagoModel> lista = business.GetAll();
                string content = "";
                foreach (MedioPagoModel item in lista)
                {
                    content += "<tr>" +
                    "<td>" + item.Id + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.FechaRegistro + "</td>" +
                  "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                    "<td><span class=\"col-md-12\"><a href=\"MedioPagoEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver</a></span>" +
                    "<span class=\"col-md-12\"><a href=\"MedioPagoEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"MedioPagoList.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedioPagoEdit.aspx");
        }

        public void CambioEstado(int id)
        {
            new MedioPagoCliente(llave).CambiarEstadoMedioPago(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "MedioPagoList.aspx", "success");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }
    }
}
