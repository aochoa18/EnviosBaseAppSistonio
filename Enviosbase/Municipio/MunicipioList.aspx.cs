using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Municipio
{
    public partial class MunicipioList : System.Web.UI.Page
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
                MunicipioCliente business = new MunicipioCliente(llave);
                List<MunicipioModel> lista = business.GetAll();
                string content = "";
                foreach (MunicipioModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + new DepartamentoCliente(llave).GetById(item.IdDepto).Nombre + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.FechaRegistro + "</td>" +
                        "<td>" + Estado(Convert.ToBoolean(item.Estado)) + "</td>" +
                        "<td><span class=\"col-md-12\"><a href=\"MunicipioEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i> Ver </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"MunicipioEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> Editar </a></span>" +
                        "<span class=\"col-md-12\"><a href=\"MunicipioList.aspx?Estado=1&Id=" + item.Id + "\"><i class=\"fa fa-trash\"></i> Cambiar estado </a></span>" +
                        "</td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("MunicipioEdit.aspx");
        }

        public void CambioEstado(int id)
        {
            new MunicipioCliente(llave).CambiarEstadoMunicipio(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "MunicipioList.aspx", "success");
        }

        public string Estado(bool state)
        {
            if (state) return "Activo"; else return "Inactivo";
        }
    }
}
