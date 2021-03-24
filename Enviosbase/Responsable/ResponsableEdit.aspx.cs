using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enviosbase.Responsable
{
    public partial class ResponsableEdit : System.Web.UI.Page
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
                cbIdPais.DataSource = new PaisCliente(llave).GetAll();
                cbIdPais.DataTextField = "Nombre";
                cbIdPais.DataValueField = "Id";
                cbIdPais.DataBind();
                cbIdPais.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdDepto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    ResponsableModel obj = new ResponsableCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    txtDocumento.Text = obj.Documento;
                    cbIdPais.SelectedValue = obj.IdPais.ToString();
                    cbIdPais_SelectedIndexChanged(cbIdPais, EventArgs.Empty);
                    cbIdDepto.SelectedValue = obj.IdDepto.ToString();
                    cbIdDepto_SelectedIndexChanged(cbIdDepto, EventArgs.Empty);
                    cbIdMunicipio.SelectedValue = obj.IdMunicipio.ToString();
                    txtDireccion.Text = obj.Direccion;
                    txtTelefono.Text = obj.Telefono;
                    txtCelular.Text = obj.Celular;
                    txtCorreo.Text = obj.Correo;
                    hdEstado.Value = obj.Estado.ToString();
                    // this.txtFechaRegistro.Text = obj.FechaRegistro == null ? null : obj.FechaRegistro.ToString();
                    // this.txtIdUsuarioRegistro.Text = obj.IdUsuarioRegistro == null ? null : obj.IdUsuarioRegistro.ToString();
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
                ResponsableModel obj;
                ResponsableCliente business = new ResponsableCliente(llave);
                obj = new ResponsableModel();
                obj.Nombre = txtNombre.Text;
                obj.Documento = txtDocumento.Text;
                obj.IdPais = int.Parse(cbIdPais.SelectedValue);
                obj.IdDepto = int.Parse(cbIdDepto.SelectedValue);
                obj.IdMunicipio = int.Parse(cbIdMunicipio.SelectedValue);
                obj.Direccion = txtDireccion.Text;
                obj.Telefono = txtTelefono.Text;
                obj.Celular = txtCelular.Text;
                obj.Correo = txtCorreo.Text;
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
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay un responsable creado con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "ResponsableList.aspx", "success");
            }
            catch (Exception ex)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResponsableList.aspx");
        }

        protected void cbIdPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIdDepto.DataSource = new DepartamentoCliente(llave).GetByPais(int.Parse(cbIdPais.SelectedValue));
            cbIdDepto.DataTextField = "Nombre";
            cbIdDepto.DataValueField = "Id";
            cbIdDepto.DataBind();
            cbIdDepto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

            cbIdMunicipio.DataSource = null;
            cbIdMunicipio.Items.Clear();
            cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));
        }

        protected void cbIdDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIdMunicipio.DataSource = new MunicipioCliente(llave).GetByDepartamento(int.Parse(cbIdDepto.SelectedValue));
            cbIdMunicipio.DataTextField = "Nombre";
            cbIdMunicipio.DataValueField = "Id";
            cbIdMunicipio.DataBind();
            cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));
        }
    }
}
