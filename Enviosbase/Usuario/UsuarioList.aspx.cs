using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Usuario
{
    public partial class UsuarioList : System.Web.UI.Page
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
                UsuarioCliente business = new UsuarioCliente(llave);
                List<UsuarioModel> lista = business.GetAll();
                string content = "";
                foreach (UsuarioModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.ID + "</td>" +
                        "<td>" + item.Nombres + "</td>" +
                        "<td>" + item.Apellidos + "</td>" +
                        "<td>" + item.UserLogin + "</td>" +
                        //"<td>" + item.PasswordLogin + "</td>" +
                        "<td>" + item.Correo + "</td>" +
                        "<td>" + item.Telefono + "</td>" +
                        "<td>" + new TipoUsuarioCliente(llave).GetById(item.IdTipoUsuario).Nombre + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + new UsuarioCliente(llave).GetById(item.IdUsuario.Value).UserLogin + "</td>" +
                        "<td><span class=\"col-lg-12\"><a href=\"UsuarioEdit.aspx?View=0&Id=" + item.ID + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-12\"><a href=\"UsuarioEdit.aspx?View=1&Id=" + item.ID + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioEdit.aspx");
        }
    }
}
