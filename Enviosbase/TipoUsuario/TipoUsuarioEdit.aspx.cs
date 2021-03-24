using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.TipoUsuario
{
    public partial class TipoUsuarioEdit : System.Web.UI.Page
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
                    TipoUsuarioModel obj = new TipoUsuarioCliente(llave).GetById(id);

                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    hdEstado.Value = obj.Estado.ToString();
                    //this.txtFechaRegistro.Text = obj.FechaRegistro.ToString();
                    //this.txtIdUsuario.Text = obj.IdUsuario == null ? null : obj.IdUsuario.ToString();
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
                TipoUsuarioModel obj;
                TipoUsuarioCliente business = new TipoUsuarioCliente(llave);
                obj = new TipoUsuarioModel();

                obj.Nombre = txtNombre.Text;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                obj.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    business.Update(obj);
                }
                else
                {
                    business.Create(obj);
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "TipoUsuarioList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipoUsuarioList.aspx");
        }
    }
}
