using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.Web.UI;

namespace Enviosbase.TipoVehiculo
{
    public partial class TipoVehiculoEdit : System.Web.UI.Page
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
                    TipoVehiculoModel obj = new TipoVehiculoCliente(llave).GetById(id);
                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    hdEstado.Value = obj.Estado.ToString();
                    //this.txtFechaRegistro.Text = obj.FechaRegistro == null ? null : obj.FechaRegistro.ToString();
                    //this.txtIdUsuarioRegistro.Text = obj.IdUsuarioRegistro == null ? null : obj.IdUsuarioRegistro.ToString();
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
                TipoVehiculoModel obj;
                TipoVehiculoCliente business = new TipoVehiculoCliente(llave);
                obj = new TipoVehiculoModel();
                obj.Nombre = txtNombre.Text;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                obj.IdUsuarioRegistro = int.Parse(Session["IdUsuario"].ToString());
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
                        ltScripts.Text = Business.Utils.MessageBox("Atenci??n", "Hay un tipo de vehiculo creado con la misma informaci??n, por favor verifique la informaci??n e intente nuevamente", null, "error");
                        return;
                    }
                }
                ltScripts.Text = Business.Utils.MessageBox("Atenci??n", "El registro ha sido guardado exit??samente", "TipoVehiculoList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atenci??n", "No pudo ser guardado el registro, por favor verifique su informaci??n e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TipoVehiculoList.aspx");
        }
    }
}
