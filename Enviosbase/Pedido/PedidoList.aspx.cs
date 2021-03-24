using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enviosbase.Pedido
{
    public partial class PedidoList : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (Request.QueryString["IdEstado"]==null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                int Estado = int.Parse(Request.QueryString["IdEstado"].ToString());
                PedidoCliente Cliente = new PedidoCliente(llave);
                List<PedidoModel> lista = Cliente.GetAll().Where(x => x.IdEstadoPedido == Estado).ToList();
                string content = "";
                foreach (PedidoModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + new ClienteCliente(llave).GetById(item.IdCliente).Nombre + "</td>" +
                        "<td>" + item.Direccion + "</td>" +
                        "<td>" + new PaisCliente(llave).GetById(item.IdPais).Nombre + "</td>" +
                        "<td>" + new DepartamentoCliente(llave).GetById(item.IdDepto).Nombre + "</td>" +
                        "<td>" + new MunicipioCliente(llave).GetById(item.IdMunicipio).Nombre + "</td>" +
                        "<td>" + item.Observaciones + "</td>" +
                        "<td>" + item.FechaEntrega + "</td>" +
                        "<td>" + new EstadoPedidoCliente(llave).GetById(item.IdEstadoPedido).Nombre + "</td>" +
                        "<td>" + ((item.IdDomiciliario == null) ? "" : new DomiciliarioCliente(llave).GetById(item.IdDomiciliario.GetValueOrDefault()).Nombre) + "</td>" +
                        "<td><span class=\"col-lg-12\"><a href=\"PedidoEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span></td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PedidoEdit.aspx");
        }
    }
}
