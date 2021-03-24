using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enviosbase.Usuario
{
    public partial class UsuarioEdit : System.Web.UI.Page
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
                cbIdTipoUsuario.DataSource = new TipoUsuarioCliente(llave).GetAll();
                cbIdTipoUsuario.DataTextField = "Nombre";
                cbIdTipoUsuario.DataValueField = "Id";
                cbIdTipoUsuario.DataBind();
                cbIdTipoUsuario.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    //WcfEcommerceService.UsuarioModel obj = clientService.ConsultarUsuarioPorId(id);
                    UsuarioModel obj = new UsuarioModel();

                    lbId.Text = obj.ID.ToString();
                    txtNombres.Text = obj.Nombres;
                    txtApellidos.Text = obj.Apellidos;
                    txtUserLogin.Text = obj.UserLogin;
                    txtPasswordLogin.Text = obj.PasswordLogin;
                    txtCorreo.Text = obj.Correo;
                    txtTelefono.Text = obj.Telefono;
                    cbIdTipoUsuario.SelectedValue = obj.IdTipoUsuario.ToString();
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
                //WcfEcommerceService.UsuarioModel obj = new WcfEcommerceService.UsuarioModel();
                UsuarioModel obj = new UsuarioModel();
                UsuarioCliente business = new UsuarioCliente(llave);
                string hash = "";
                hash = RationalSWUtils.Criptography.GetSHA512(txtPasswordLogin.Text);
                obj.Nombres = txtNombres.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.UserLogin = txtUserLogin.Text;
                obj.PasswordLogin = hash;
                obj.Correo = txtCorreo.Text;
                obj.Telefono = txtTelefono.Text;
                obj.IdTipoUsuario = int.Parse(cbIdTipoUsuario.SelectedValue);
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                obj.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                if (Request.QueryString["Id"] != null)
                {
                    obj.ID = int.Parse(Request.QueryString["Id"]);
                    //clientService.ActualizarUsuario(obj);
                }
                else
                {
                    //clientService.GuardarUsuario(obj);
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "UsuarioList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioList.aspx");
        }
    }
}
