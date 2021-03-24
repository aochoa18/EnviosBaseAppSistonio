using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DocumentFormat.OpenXml.Drawing;

namespace Enviosbase.Domiciliario
{
    public partial class DomiciliarioEdit : System.Web.UI.Page
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
                if (Request.QueryString["Estado"] == "1")
                {
                    CambioEstado(int.Parse(Request.QueryString["Id"].ToString()));
                }

                if (Request.QueryString["Notificacion"] == "1")
                {
                    EnviarUsuarioContraseña(int.Parse(Request.QueryString["Id"].ToString()));
                }

                cbIdPais.DataSource = new PaisCliente(llave).GetAll();
                cbIdPais.DataTextField = "Nombre";
                cbIdPais.DataValueField = "Id";
                cbIdPais.DataBind();
                cbIdPais.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdDepto.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                cbIdTipoVehiculo.DataSource = new TipoVehiculoCliente(llave).GetAll();
                cbIdTipoVehiculo.DataTextField = "Nombre";
                cbIdTipoVehiculo.DataValueField = "Id";
                cbIdTipoVehiculo.DataBind();
                cbIdTipoVehiculo.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdMarca.DataSource = new MarcaCliente(llave).GetAll();
                cbIdMarca.DataTextField = "Nombre";
                cbIdMarca.DataValueField = "Id";
                cbIdMarca.DataBind();
                cbIdMarca.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    DomiciliarioModel obj = new DomiciliarioCliente(llave).GetById(id);
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
                    cbIdTipoVehiculo.SelectedValue = obj.IdTipoVehiculo.ToString();
                    cbIdMarca.SelectedValue = obj.IdMarca.ToString();
                    txtModelo.Text = obj.Modelo;
                    txtPlaca.Text = obj.Placa;
                    txtCorreo.Value = obj.Correo;
                    hdEstado.Value = obj.Estado.ToString();
                    hdnFileDoc.Value = obj.ImagenDocumento.ToString();
                    hdnFileLic.Value = obj.ImagenPase.ToString();
                    hdnFileSoat.Value = obj.ImagenSoat.ToString();
                    hdnFileTar.Value = obj.ImagenTarjetaPropiedad.ToString();
                    hdnFoto.Value = obj.Foto.ToString();
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
                DomiciliarioModel obj;
                DomiciliarioCliente business = new DomiciliarioCliente(llave);

                if (Request.QueryString["Id"] != null)
                { obj = new DomiciliarioCliente(llave).GetById(int.Parse(Request.QueryString["Id"].ToString())); }
                else { obj = new DomiciliarioModel(); }

                string hash = "";
                string filePath = "";
                string filePath1 = "";
                string filePath2 = "";
                string filePath3 = "";
                string filePath4 = "";
                string rutaArchivo = "";
                string rutaArchivo1 = "";
                string rutaArchivo2 = "";
                string rutaArchivo3 = "";
                string rutaArchivo4 = "";

                obj.Nombre = txtNombre.Text;
                obj.Documento = txtDocumento.Text;
                obj.IdPais = int.Parse(cbIdPais.SelectedValue);
                obj.IdDepto = int.Parse(cbIdDepto.SelectedValue);
                obj.IdMunicipio = int.Parse(cbIdMunicipio.SelectedValue);
                obj.Direccion = txtDireccion.Text;
                obj.Telefono = txtTelefono.Text;
                obj.Celular = txtCelular.Text;
                obj.IdTipoVehiculo = int.Parse(cbIdTipoVehiculo.SelectedValue);
                obj.IdMarca = int.Parse(cbIdMarca.SelectedValue);
                obj.Modelo = txtModelo.Text;
                obj.Placa = txtPlaca.Text;
                obj.UserLogin = txtDocumento.Text;
                obj.Correo = txtCorreo.Value;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;

                if (fnArchivoFoto.HasFile)
                {
                    if (validarTamaño(fnArchivoFoto.FileBytes.Length))
                    {
                        filePath = "/ImagenesDomiciliario/" + obj.Documento + "/" + fnArchivoFoto.FileName;
                        string rutaInterna = Server.MapPath("/Archivos" + filePath);
                        if (!Directory.Exists(System.IO.Path.GetDirectoryName(rutaInterna)))
                            Directory.CreateDirectory(Path.GetDirectoryName(rutaInterna));
                        fnArchivoFoto.SaveAs(rutaInterna);
                        rutaArchivo = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath;
                    }
                    else
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto del domiciliario supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                        return;
                    }
                }
                else
                {
                    rutaArchivo = hdnFoto.Value;
                }


                if (fnArchivoDoc.HasFile)
                {
                    if (validarTamaño(fnArchivoDoc.FileBytes.Length))
                    {
                        filePath1 = "/ImagenesDomiciliario/" + obj.Documento + "/" + fnArchivoDoc.FileName;
                        string rutaInterna = Server.MapPath("/Archivos" + filePath1);
                        if (!Directory.Exists(Path.GetDirectoryName(rutaInterna)))
                            Directory.CreateDirectory(Path.GetDirectoryName(rutaInterna));
                        fnArchivoDoc.SaveAs(rutaInterna);
                        rutaArchivo1 = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath1;
                    }
                    else
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto del documento supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                        return;
                    }
                }
                else
                {
                    rutaArchivo1 = hdnFileDoc.Value;
                }

                if (fnArchivoPase.HasFile)
                {
                    if (validarTamaño(fnArchivoPase.FileBytes.Length))
                    {
                        filePath2 = "/ImagenesDomiciliario/" + obj.Documento + "/" + fnArchivoPase.FileName;
                        string rutaInterna = Server.MapPath("/Archivos" + filePath2);
                        if (!Directory.Exists(Path.GetDirectoryName(rutaInterna)))
                            Directory.CreateDirectory(Path.GetDirectoryName(rutaInterna));
                        fnArchivoPase.SaveAs(rutaInterna);
                        rutaArchivo2 = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath2;
                    }
                    else
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto de la licencia de conducción supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                        return;
                    }
                }
                else
                {
                    rutaArchivo2 = hdnFileLic.Value;
                }

                if (fnArchivoSoat.HasFile)
                {
                    if (validarTamaño(fnArchivoSoat.FileBytes.Length))
                    {
                        filePath3 = "/ImagenesDomiciliario/" + obj.Documento + "/" + fnArchivoSoat.FileName;
                        string rutaInterna = Server.MapPath("/Archivos" + filePath3);
                        if (!Directory.Exists(Path.GetDirectoryName(rutaInterna)))
                            Directory.CreateDirectory(Path.GetDirectoryName(rutaInterna));
                        fnArchivoSoat.SaveAs(rutaInterna);
                        rutaArchivo3 = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath3;
                    }
                    else
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto del SOAT supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                        return;
                    }
                }
                else
                {
                    rutaArchivo3 = hdnFileSoat.Value;
                }

                if (fnArchivoTarjeta.HasFile)
                {
                    if (validarTamaño(fnArchivoTarjeta.FileBytes.Length))
                    {
                        filePath4 = "/ImagenesDomiciliario/" + obj.Documento + "/" + fnArchivoTarjeta.FileName;
                        string rutaInterna = Server.MapPath("/Archivos" + filePath4);
                        if (!Directory.Exists(Path.GetDirectoryName(rutaInterna)))
                            Directory.CreateDirectory(Path.GetDirectoryName(rutaInterna));
                        fnArchivoTarjeta.SaveAs(rutaInterna);
                        rutaArchivo4 = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath4;
                    }
                    else
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto de la tarjeta de propiedad supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                        return;
                    }
                }
                else
                {
                    rutaArchivo4 = hdnFileTar.Value;
                }

                obj.ImagenDocumento = rutaArchivo1;
                obj.ImagenPase = rutaArchivo2;
                obj.ImagenSoat = rutaArchivo3;
                obj.ImagenTarjetaPropiedad = rutaArchivo4;
                obj.Foto = rutaArchivo;

                // obj.IdUsuarioRegistro = int.Parse(this.txtIdUsuarioRegistro.Text);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    business.Update(obj);
                }
                else
                {
                    int longitud = 7;
                    Guid miGuid = Guid.NewGuid();
                    string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
                    hash = RationalSWUtils.Criptography.CreateMD5(token);
                    obj.PasswordLogin = hash;
                    obj = business.Create(obj);

                    if (obj.Id == 0)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay un domiciliario creado con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                        return;
                    }

                    new Business.EmailBussines().SendMailCreateUserDom(txtDocumento.Text, token, obj.Nombre, txtCorreo.Value);
                }
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "DomiciliarioList.aspx", "success");
            }
            catch (Exception ex)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        public bool validarTamaño(int tamaño)
        {
            if (tamaño > int.Parse(System.Configuration.ConfigurationManager.AppSettings["tamañoArchivos"].ToString())) return false; else return true;
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DomiciliarioList.aspx");
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


        public void EnviarUsuarioContraseña(int idDomiciliario)
        {
            DomiciliarioCliente usuarioBusiness = new DomiciliarioCliente(llave);

            DomiciliarioModel model = new DomiciliarioCliente(llave).GetById(idDomiciliario);

            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            model.PasswordLogin = RationalSWUtils.Criptography.CreateMD5(token);
            usuarioBusiness.Update(model);

            new Business.EmailBussines().SendMailRememberUserDom(model.Documento, token, model.Nombre, model.Correo);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "Se ha enviado el correo de notificación a " + model.Correo, "DomiciliarioList.aspx", "success");

        }

        public void CambioEstado(int id)
        {
            new DomiciliarioCliente(llave).CambiarEstadoDomiciliario(id);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "DomiciliarioList.aspx", "success");
        }

    }
}
