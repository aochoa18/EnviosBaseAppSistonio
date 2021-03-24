using eCommerceSE.Cliente;
using eCommerceSE.Model;
using Enviosbase.Business;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enviosbase.Pedido
{
    public partial class PedidoEdit : System.Web.UI.Page
    {
        string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                cbIdCliente.DataSource = new ClienteCliente(llave).GetAll();
                cbIdCliente.DataTextField = "Nombre";
                cbIdCliente.DataValueField = "Id";
                cbIdCliente.DataBind();
                cbIdCliente.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdPais.DataSource = new PaisCliente(llave).GetAll();
                cbIdPais.DataTextField = "Nombre";
                cbIdPais.DataValueField = "Id";
                cbIdPais.DataBind();
                cbIdPais.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdDepto.DataSource = new DepartamentoCliente(llave).GetAll();
                cbIdDepto.DataTextField = "Nombre";
                cbIdDepto.DataValueField = "Id";
                cbIdDepto.DataBind();
                cbIdDepto.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdMunicipio.DataSource = new MunicipioCliente(llave).GetAll();
                cbIdMunicipio.DataTextField = "Nombre";
                cbIdMunicipio.DataValueField = "Id";
                cbIdMunicipio.DataBind();
                cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdEstadoPedido.DataSource = new EstadoPedidoCliente(llave).GetAll();
                cbIdEstadoPedido.DataTextField = "Nombre";
                cbIdEstadoPedido.DataValueField = "Id";
                cbIdEstadoPedido.DataBind();
                cbIdEstadoPedido.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdDomiciliario.DataSource = new DomiciliarioCliente(llave).GetAll();
                cbIdDomiciliario.DataTextField = "Nombre";
                cbIdDomiciliario.DataValueField = "Id";
                cbIdDomiciliario.DataBind();
                cbIdDomiciliario.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    PedidoModel obj = new PedidoCliente(llave).GetById(id);

                    lbId.Text = obj.Id.ToString();
                    cbIdCliente.SelectedValue = obj.IdCliente.ToString();
                    //txtNoPedido.Text = obj.NoPedido;
                    txtDireccion.Text = obj.Direccion;
                    cbIdPais.SelectedValue = obj.IdPais.ToString();
                    cbIdDepto.SelectedValue = obj.IdDepto.ToString();
                    cbIdMunicipio.SelectedValue = obj.IdMunicipio.ToString();
                    txtObservaciones.Text = obj.Observaciones;
                    txtFechaEntrega.Text = obj.FechaEntrega == null ? null : obj.FechaEntrega.Value.ToString("yyyy-MM-dd");
                    cbIdEstadoPedido.SelectedValue = obj.IdEstadoPedido.ToString();
                    hdEstado.Value = obj.Estado.ToString();
                    txtFechaRegistro.Text = obj.FechaRegistro == null ? null : obj.FechaRegistro.ToString();
                    cbIdDomiciliario.SelectedValue = obj.IdDomiciliario == null ? null : obj.IdDomiciliario.ToString();

                    int? medioPago = new PagoCliente(llave).GetByPedido(obj.Id)[0].IdMedioPago;

                    txtMetodoPago.Text = (medioPago.HasValue) ? new MedioPagoCliente(llave).GetById(medioPago.Value).Nombre : "";

                    ProductosPedidoCliente Cliente = new ProductosPedidoCliente(llave);
                    List<ProductosPedidoModel> lista = Cliente.GetByPedido(obj.Id);
                    string content = "";
                    foreach (ProductosPedidoModel item in lista)
                    {
                        content += "<tr>" +

                            "<td>" + item.Id + "</td>" +
                            "<td>" + new ProductoCliente(llave).GetById(item.IdProducto).Nombre + "</td>" +
                            "<td>" + item.Cantidad + "</td>" +
                            "<td>" + string.Format("{0:C0}", item.Precio) + "</td>" +
                            "<td>" + string.Format("{0:C0}", item.Precio * item.Cantidad) + "</td>" +
                            "</tr>";
                    }
                    ltTableItems.Text = content;
                }
                else
                {
                    hdEstado.Value = true.ToString();
                }
                Utils.DisableForm(Controls);
                cbIdDomiciliario.Enabled = true;
                cbIdEstadoPedido.Enabled = true;
                txtFechaEntrega.Enabled = true;
                btnCancel.Enabled = true;
                btnExcel.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoModel obj;
                PedidoCliente business = new PedidoCliente(llave);
                obj = new PedidoModel();

                obj.IdCliente = int.Parse(cbIdCliente.SelectedValue);
                obj.NoPedido = "";
                obj.Direccion = txtDireccion.Text;
                obj.IdPais = int.Parse(cbIdPais.SelectedValue);
                obj.IdDepto = int.Parse(cbIdDepto.SelectedValue);
                obj.IdMunicipio = int.Parse(cbIdMunicipio.SelectedValue);
                obj.Observaciones = txtObservaciones.Text;
                obj.FechaEntrega = (txtFechaEntrega.Text == "") ? (DateTime?)null : DateTime.Parse(txtFechaEntrega.Text);
                obj.IdEstadoPedido = int.Parse(cbIdEstadoPedido.SelectedValue);
                obj.Estado = hdEstado.Value.Trim();
                obj.FechaRegistro = DateTime.Parse(txtFechaRegistro.Text);
                obj.IdDomiciliario = int.Parse(cbIdDomiciliario.SelectedValue);
                obj.IdEstablecimiento = 1;
                //obj.geolat = double.Parse(this.txtgeolat.Text);
                //obj.geolon = double.Parse(this.txtgeolon.Text);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    business.Update(obj);
                    if (obj.IdEstadoPedido == 3 && obj.IdDomiciliario != null && obj.FechaEntrega != null)
                    {
                        var cliente = new ClienteCliente(llave).GetById(obj.IdCliente);
                        EmailBussines emailBussines = new EmailBussines();
                        DateTime date1 = obj.FechaEntrega.Value;
                        emailBussines.SendMailEnRuta(cliente.Nombre, cliente.Correo, date1.ToString("dddd dd MMMM", CultureInfo.CreateSpecificCulture("es-es")));
                    }
                }
                else
                {
                    business.Create(obj);
                }
                ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "PedidoList.aspx?IdEstado=" + obj.IdEstadoPedido, "success");
            }
            catch (Exception ex)
            {
                using (var stream = new System.IO.StreamWriter(@"C:\temp\log.log", true))
                {
                    stream.WriteLine(ex.Message);

                    stream.Flush();
                    stream.Close();
                }
                ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PedidoList.aspx");
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string path = "/Archivos/Excel/" + Request.QueryString["Id"].ToString() + ".xlsx";
            string ruta = Server.MapPath(path);
            try
            {
                int pedido = int.Parse(Request.QueryString["Id"].ToString());
                ProductosPedidoCliente Cliente = new ProductosPedidoCliente(llave);
                List<ProductosPedidoModel> lista = Cliente.GetByPedido(pedido);

                SLDocument sl = new SLDocument();

                int indiceColumna = 0;
                string[] columnas = { "Id", "Producto", "Cantidad", "Precio", "Precio Total" };
                foreach (string col in columnas)  //Columnas
                {
                    indiceColumna++;
                    sl.SetCellValue(1, indiceColumna, col);
                }

                int indiceFila = 0;

                foreach (ProductosPedidoModel item in lista)
                {
                    indiceFila++;
                    sl.SetCellValue(indiceFila + 1, 1, item.Id);
                    sl.SetCellValue(indiceFila + 1, 2, new ProductoCliente(llave).GetById(item.IdProducto).Nombre);
                    sl.SetCellValue(indiceFila + 1, 3, item.Cantidad.Value);
                    sl.SetCellValue(indiceFila + 1, 4, item.Precio.Value);
                    sl.SetCellValue(indiceFila + 1, 5, item.Precio.Value * item.Cantidad.Value);
                }

                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(ruta);
            }
            catch (Exception ex)
            {
                ltScripts.Text = Utils.MessageBox("Atención", "No se pudo generar el archivo. " + ex.Message, null, "error");
                throw new Exception(ex.Message);
                return;
            }
            string attachment = "attachment; filename=" + Path.GetFileName(ruta);
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";

            Response.WriteFile(ruta);

            Response.End();
        }
    }
}
