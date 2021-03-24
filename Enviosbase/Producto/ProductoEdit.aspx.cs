using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enviosbase.Producto
{
    public partial class ProductoEdit : System.Web.UI.Page
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
                cbIdCategoria.DataSource = new CategoriaProductoCliente(llave).GetAll();
                cbIdCategoria.DataTextField = "Nombre";
                cbIdCategoria.DataValueField = "Id";
                cbIdCategoria.DataBind();
                cbIdCategoria.Items.Insert(0, new ListItem("[Seleccione]", ""));

                /*this.cbIdEstablecimiento.DataSource = new EstablecimientoCliente(llave).GetAll();
                this.cbIdEstablecimiento.DataTextField = "Nombre";
                this.cbIdEstablecimiento.DataValueField = "Id";
                this.cbIdEstablecimiento.DataBind();
                this.cbIdEstablecimiento.Items.Insert(0, new ListItem("[Seleccione]", ""));*/

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    ProductoModel obj = new ProductoCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    txtDescripcion.Text = obj.Descripcion;
                    txtPresentacion.Text = obj.Presentacion;
                    txtPrecio.Text = obj.Precio == null ? null : obj.Precio.ToString();
                    hdnFileImage.Value = obj.Imagen;
                    hdEstado.Value = obj.Estado.ToString();
                    //this.txtIdUsuarioRegistro.Text = obj.IdUsuarioRegistro == null ? null : obj.IdUsuarioRegistro.ToString();
                    cbIdCategoria.SelectedValue = obj.IdCategoria == null ? null : obj.IdCategoria.ToString();
                    txtCodigoSKU.Text = obj.CodigoSKU;
                    hdIdEstablecimiento.Value = obj.IdEstablecimiento == null ? null : obj.IdEstablecimiento.ToString();
                    txtPrecioPromocion.Text = obj.PrecioPromocion == null ? null : obj.PrecioPromocion.ToString();
                    txtPorcentajePromocion.Text = obj.PorcentajePromocion == null ? null : obj.PorcentajePromocion.ToString();
                    txtCodigo.Text = obj.Codigo;
                }
                else
                {
                    hdEstado.Value = true.ToString();
                    hdIdEstablecimiento.Value = (Session["IdEstablecimiento"] != null) ? Session["IdEstablecimiento"].ToString() : "0";
                }


                if (Request.QueryString["View"] == "0")
                {
                    Business.Utils.DisableForm(Controls);
                    btnCancel.Enabled = true;
                }
            }

        }

        public bool validarTamaño(int tamaño)
        {
            if (tamaño > int.Parse(System.Configuration.ConfigurationManager.AppSettings["tamañoArchivos"].ToString())) return false; else return true;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ProductoModel obj;
                obj = new ProductoModel();

                string filePath = "";
                if (fnImagen.HasFile)
                {
                    if (validarTamaño(fnImagen.FileBytes.Length))
                    {
                        filePath = "/ImagenesProductos/" + Session["IdEstablecimiento"].ToString() + '/' + fnImagen.FileName;
                        string rutaInterna = Server.MapPath("/Archivos" + filePath);
                        if (!Directory.Exists(Path.GetDirectoryName(rutaInterna)))
                            Directory.CreateDirectory(Path.GetDirectoryName(rutaInterna));
                        fnImagen.SaveAs(rutaInterna);
                        obj.Imagen = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath;
                    }
                    else
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                        return;
                    }
                }
                else
                {
                    filePath = hdnFileImage.Value;
                    obj.Imagen = filePath;
                }

                ProductoCliente business = new ProductoCliente(llave);

                obj.Nombre = txtNombre.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Presentacion = txtPresentacion.Text;
                obj.Precio = double.Parse(txtPrecio.Text);
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.IdUsuarioRegistro = int.Parse(Session["IdUsuario"].ToString());
                obj.IdCategoria = int.Parse(cbIdCategoria.SelectedValue);
                obj.CodigoSKU = txtCodigoSKU.Text;
                obj.IdEstablecimiento = int.Parse(hdIdEstablecimiento.Value);
                obj.PrecioPromocion = double.Parse(txtPrecioPromocion.Text);
                obj.PorcentajePromocion = double.Parse(txtPorcentajePromocion.Text);
                obj.Codigo = txtCodigo.Text;
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    business.Update(obj);
                }
                else
                {
                    obj = business.Create(obj);

                    if (obj.Id == 0)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay un producto creado con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }


                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "ProductoList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductoList.aspx");
        }
    }
}
