using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Responsable
{
    public partial class ResponsableList : System.Web.UI.Page
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
                ResponsableCliente business = new ResponsableCliente(llave);
                List<ResponsableModel> lista = business.GetAll();
                string content = "";
                foreach (ResponsableModel item in lista)
                {

                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.Documento + "</td>" +
                        "<td>" + new PaisCliente(llave).GetById(item.IdPais).Nombre + "</td>" +
                        "<td>" + new DepartamentoCliente(llave).GetById(item.IdDepto).Nombre + "</td>" +
                        "<td>" + new MunicipioCliente(llave).GetById(int.Parse(item.IdMunicipio.ToString())).Nombre + "</td>" +
                        "<td>" + item.Direccion + "</td>" +
                        "<td>" + item.Telefono + "</td>" +
                        "<td>" + item.Celular + "</td>" +
                        "<td>" + item.Correo + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"ResponsableEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"ResponsableEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"ResponsableList.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResponsableEdit.aspx");
        }

        public void CambioEstado(int id)
        {
            new ResponsableCliente(llave).CambiarEstadoResponsable(id);
            ltScripts.Text = Business.Utils.MessageBox("Atenci�n", "El cambio de estado se realizo exit�samente", "ResponsableList.aspx", "success");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }

    }
}
