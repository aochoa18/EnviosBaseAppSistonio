using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace Enviosbase.CategoriaEstablecimiento
{
    public partial class CategoriaEstablecimientoEdit : System.Web.UI.Page
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
                    int id = int.Parse(Request.QueryString["Id"]);
                    CategoriaEstablecimientoModel obj = new CategoriaEstablecimientoCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    txtDescripcion.Text = obj.Descripcion;
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
                CategoriaEstablecimientoModel obj = new CategoriaEstablecimientoModel();
                string rutaArchivo = "";
                if (fnImagen.HasFile)
                {
                    rutaArchivo = Path.Combine(ConfigurationManager.AppSettings["RutaArchivos"].ToString() + "ImagenesCatEsta/", Path.GetFileName(fnImagen.FileName));
                    string path = Path.Combine(Server.MapPath("~/Archivos/ImagenesCatEsta/"), Path.GetFileName(fnImagen.FileName));
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    fnImagen.SaveAs(path);
                }
                else
                {
                    rutaArchivo = hdnFileImage.Value;
                }

                obj.Nombre = txtNombre.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.Imagen = rutaArchivo;
                obj.FechaRegistro = DateTime.Now;
                obj.IdUsuarioRegistro = int.Parse(Session["IdUsuario"].ToString());
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    new CategoriaEstablecimientoCliente(llave).Update(obj);
                }
                else
                {
                    obj = new CategoriaEstablecimientoCliente(llave).Create(obj);
                    if (obj.Id == 0)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay una categoria de establecimiento creada con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "CategoriaEstablecimientoList.aspx", "success");
            }
            catch (Exception ex)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaEstablecimientoList.aspx");
        }
    }
}
