using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enviosbase.Departamento
{
    public partial class DepartamentoEdit : System.Web.UI.Page
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

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    DepartamentoModel obj = new DepartamentoCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    cbIdPais.SelectedValue = obj.IdPais.ToString();
                    txtNombre.Text = obj.Nombre;
                    hdEstado.Value = obj.Estado.ToString();
                    //this.txtFechaRegistro.Text = obj.FechaRegistro == null ? null : obj.FechaRegistro.ToString();
                }
                else
                {
                    hdEstado.Value = true.ToString();
                }


                if (Request.QueryString["View"] == "0")
                {
                    Enviosbase.Business.Utils.DisableForm(Controls);
                    btnCancel.Enabled = true;
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DepartamentoModel obj;
                obj = new DepartamentoModel();
                obj.IdPais = int.Parse(cbIdPais.SelectedValue);
                obj.Nombre = txtNombre.Text;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    new DepartamentoCliente(llave).Update(obj);
                }
                else
                {
                    obj = new DepartamentoCliente(llave).Create(obj);
                    if (obj.Id == 0)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay un departamento creado con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "DepartamentoList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartamentoList.aspx");
        }
    }
}
