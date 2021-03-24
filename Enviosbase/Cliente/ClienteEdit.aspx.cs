using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.Cliente
{
    public partial class ClienteEdit : System.Web.UI.Page
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
                    ClienteModel obj = new ClienteCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    //this.txtDocumento.Text = obj.Documento;
                    txtCorreo.Text = obj.Correo;
                    txtDireccion.Text = obj.Direccion;
                    txtTelefono.Text = obj.Telefono;
                    txtCelular.Text = obj.Celular;
                    //this.cbIdPais.SelectedValue = obj.IdPais.ToString();
                    //this.cbIdDepto.SelectedValue = obj.IdDepto.ToString();
                    //this.cbIdMunicipio.SelectedValue = obj.IdMunicipio.ToString();
                    //this.txtContrasena.Text = obj.Contrasena;
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
                ClienteModel obj;
                obj = new ClienteModel();
                obj.Nombre = txtNombre.Text;
                obj.Documento = "";
                obj.Correo = txtCorreo.Text;
                obj.Direccion = txtDireccion.Text;
                obj.Telefono = txtTelefono.Text;
                obj.Celular = txtCelular.Text;
                obj.IdPais = 0;
                obj.IdDepto = 0;
                obj.IdMunicipio = 0;
                obj.Contrasena = "";
                obj.Estado = bool.Parse(hdEstado.Value);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    new ClienteCliente(llave).Update(obj);
                }
                else
                {
                    new ClienteCliente(llave).Create(obj);
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "ClienteList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteList.aspx");
        }

        //protected void cbIdPais_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.cbIdDepto.DataSource = new DepartamentoCliente(llave).GetByPais(int.Parse(this.cbIdPais.SelectedValue));
        //    this.cbIdDepto.DataTextField = "Nombre";
        //    this.cbIdDepto.DataValueField = "Id";
        //    this.cbIdDepto.DataBind();
        //    this.cbIdDepto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

        //    this.cbIdMunicipio.DataSource = null;
        //    this.cbIdMunicipio.Items.Clear();
        //    this.cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));
        //}

        //protected void cbIdDepto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.cbIdMunicipio.DataSource = new MunicipioCliente(llave).GetByDepartamento(int.Parse(this.cbIdDepto.SelectedValue));
        //    this.cbIdMunicipio.DataTextField = "Nombre";
        //    this.cbIdMunicipio.DataValueField = "Id";
        //    this.cbIdMunicipio.DataBind();
        //    this.cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));
        //}
    }
}
