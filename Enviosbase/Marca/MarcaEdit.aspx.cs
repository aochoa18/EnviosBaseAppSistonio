using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Marca
{
    public partial class MarcaEdit : System.Web.UI.Page
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
                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    MarcaModel obj = new MarcaCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    hdEstado.Value = obj.Estado.ToString();
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
                MarcaModel obj;
                MarcaCliente business = new MarcaCliente(llave);
                obj = new MarcaModel();
                obj.Nombre = txtNombre.Text;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                obj.IdUsuarioRegistro = 1;
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
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay una marca creado con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "MarcaList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcaList.aspx");
        }
    }
}
