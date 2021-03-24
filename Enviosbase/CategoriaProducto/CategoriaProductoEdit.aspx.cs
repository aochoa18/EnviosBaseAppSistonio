using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace Enviosbase.CategoriaProducto
{
    public partial class CategoriaProductoEdit : System.Web.UI.Page
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
                if (Request.QueryString["Id"] != null)
                {
                    if (Request.QueryString["Estado"] == "1")
                    {
                        CambioEstado(int.Parse(Request.QueryString["Id"].ToString()));
                        Response.Redirect("CategoriaProductoList.aspx");
                    }
                    int id = int.Parse(Request.QueryString["Id"]);
                    CategoriaProductoModel obj = new CategoriaProductoCliente(llave).GetById(id);
                    lbId.Text = obj.id.ToString();
                    txtNombre.Text = obj.Nombre;
                    hdEstado.Value = obj.Estado.ToString();
                    hdnFileImage.Value = obj.Imagen;

                }
                else
                {
                    hdEstado.Value = true.ToString();
                }


                if (Request.QueryString["View"] == "0")
                {
                    Business.Utils.DisableForm(Controls);
                    btnCancel.Enabled = true;
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaProductoModel obj = new CategoriaProductoModel();

                string rutaArchivo = "";
                if (fnImagen.HasFile)
                {
                    rutaArchivo = Path.Combine(ConfigurationManager.AppSettings["RutaArchivos"].ToString() + "ImagenesCatProd/", Path.GetFileName(fnImagen.FileName));
                    string path = Path.Combine(Server.MapPath("~/Archivos/ImagenesCatProd/"), Path.GetFileName(fnImagen.FileName));
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    fnImagen.SaveAs(path);
                }
                else
                {
                    rutaArchivo = hdnFileImage.Value;
                }

                obj.Nombre = txtNombre.Text;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                obj.Imagen = rutaArchivo;
                if (Request.QueryString["Id"] != null)
                {
                    obj.id = int.Parse(Request.QueryString["Id"]);
                    new CategoriaProductoCliente(llave).Update(obj);
                }
                else
                {
                    obj = new CategoriaProductoCliente(llave).Create(obj);
                    if (obj.id == 0)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay una categoria de producto creada con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "CategoriaProductoList.aspx", "success");
            }
            catch (Exception ex)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaProductoList.aspx");
        }

        public void CambioEstado(int id)
        {
            new CategoriaProductoCliente(llave).CambiarEstadoCategoriaProducto(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "CategoriaProductoList.aspx", "success");
        }
    }
}
