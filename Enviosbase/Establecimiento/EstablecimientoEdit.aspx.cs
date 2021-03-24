using eCommerceSE.Cliente;
using eCommerceSE.Model;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Enviosbase.Establecimiento
{
    public partial class EstablecimientoEdit : Page
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

                if (Request.QueryString["Estado"] == "1")
                {
                    CambioEstado(int.Parse(Request.QueryString["Id"].ToString()));
                }

                cbIdPais.DataSource = new PaisCliente(llave).GetAll();
                cbIdPais.DataTextField = "Nombre";
                cbIdPais.DataValueField = "Id";
                cbIdPais.DataBind();
                cbIdPais.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                cbIdDepto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                cbIdMunicipio.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                cbIdResponsable.DataSource = new ResponsableCliente(llave).GetAll();
                cbIdResponsable.DataTextField = "Nombre";
                cbIdResponsable.DataValueField = "Id";
                cbIdResponsable.DataBind();
                cbIdResponsable.Items.Insert(0, new ListItem("[Seleccione]", ""));

                cbIdCategoria.DataSource = new CategoriaEstablecimientoCliente(llave).GetAll();
                cbIdCategoria.DataTextField = "Nombre";
                cbIdCategoria.DataValueField = "Id";
                cbIdCategoria.DataBind();
                cbIdCategoria.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    EstablecimientoModel obj = new EstablecimientoCliente(llave).GetById(id);

                    lbId.Text = obj.Id.ToString();
                    txtNombre.Text = obj.Nombre;
                    txtDocumento.Text = obj.Documento;
                    cbIdPais.SelectedValue = obj.IdPais.ToString();
                    cbIdPais_SelectedIndexChanged(cbIdPais, EventArgs.Empty);
                    cbIdDepto.SelectedValue = obj.IdDepto.ToString();
                    cbIdDepto_SelectedIndexChanged(cbIdDepto, EventArgs.Empty);
                    cbIdMunicipio.SelectedValue = obj.IdMunicipio.ToString();
                    txtDireccion.Text = obj.Direccion;
                    //this.txtGeoLon.Text = obj.GeoLon == null ? null : obj.GeoLon.ToString();
                    //this.txtGeoLat.Text = obj.GeoLat == null ? null : obj.GeoLat.ToString();
                    cbIdResponsable.SelectedValue = obj.IdResponsable.ToString();
                    txtTelefono.Text = obj.Telefono;
                    txtCelular.Text = obj.Celular;
                    txtCorreo.Value = obj.Correo;

                    txtHoraInicioLunes.Value = obj.HoraInicioLunes.ToString();
                    txtHoraInicioMartes.Value = obj.HoraInicioMartes.ToString();
                    txtHoraInicioMiercoles.Value = obj.HoraInicioMiercoles.ToString();
                    txtHoraInicioJueves.Value = obj.HoraInicioJueves.ToString();
                    txtHoraInicioViernes.Value = obj.HoraInicioViernes.ToString();
                    txtHoraInicioSabado.Value = obj.HoraInicioSabado.ToString();
                    txtHoraInicioDomingo.Value = obj.HoraInicioDomingo.ToString();
                    txtHoraFinLunes.Value = obj.HoraFinLunes.ToString();
                    txtHoraFinMartes.Value = obj.HoraFinMartes.ToString();
                    txtHoraFinMiercoles.Value = obj.HoraFinMiercoles.ToString();
                    txtHoraFinJueves.Value = obj.HoraFinJueves.ToString();
                    txtHoraFinViernes.Value = obj.HoraFinViernes.ToString();
                    txtHoraFinSabado.Value = obj.HoraFinSabado.ToString();
                    txtHoraFinDomingo.Value = obj.HoraFinDomingo.ToString();

                    hdEstado.Value = obj.Estado.ToString();
                    cbIdCategoria.SelectedValue = obj.IdCategoria == null ? null : obj.IdCategoria.ToString();
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
                EstablecimientoModel obj;
                int guardado = 1;
                EstablecimientoCliente business = new EstablecimientoCliente(llave);
                obj = new EstablecimientoModel();

                obj.Nombre = txtNombre.Text;
                obj.Documento = txtDocumento.Text;
                obj.IdPais = int.Parse(cbIdPais.SelectedValue);
                obj.IdDepto = int.Parse(cbIdDepto.SelectedValue);
                obj.IdMunicipio = int.Parse(cbIdMunicipio.SelectedValue);
                obj.Direccion = txtDireccion.Text;

                string address = txtDireccion.Text + ", " + cbIdMunicipio.SelectedItem.Text + ", Colombia";
                string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address), System.Configuration.ConfigurationManager.AppSettings["ClaveGEO"].ToString());

                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");
                var s = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                var x = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
                obj.GeoLat = decimal.Parse(lat.Value.ToString().Replace(x, s));
                obj.GeoLon = decimal.Parse(lng.Value.ToString().Replace(x, s));
                obj.GeoLat = (decimal)obj.GeoLat;
                obj.GeoLon = (decimal)obj.GeoLon;
                obj.IdResponsable = int.Parse(cbIdResponsable.SelectedValue);
                obj.Telefono = txtTelefono.Text;
                obj.Celular = txtCelular.Text;
                obj.Correo = txtCorreo.Value;
                obj.Estado = bool.Parse(hdEstado.Value);
                obj.FechaRegistro = DateTime.Now;
                obj.IdUsuarioRegistra = int.Parse(Session["IdUsuario"].ToString());
                obj.IdCategoria = int.Parse(cbIdCategoria.SelectedValue);
                obj.HoraInicioLunes = TimeSpan.Parse(txtHoraInicioLunes.Value);
                obj.HoraInicioMartes = TimeSpan.Parse(txtHoraInicioMartes.Value);
                obj.HoraInicioMiercoles = TimeSpan.Parse(txtHoraInicioMiercoles.Value);
                obj.HoraInicioJueves = TimeSpan.Parse(txtHoraInicioJueves.Value);
                obj.HoraInicioViernes = TimeSpan.Parse(txtHoraInicioViernes.Value);
                obj.HoraInicioSabado = TimeSpan.Parse(txtHoraInicioSabado.Value);
                obj.HoraInicioDomingo = TimeSpan.Parse(txtHoraInicioDomingo.Value);
                obj.HoraFinLunes = TimeSpan.Parse(txtHoraFinLunes.Value);
                obj.HoraFinMartes = TimeSpan.Parse(txtHoraFinMartes.Value);
                obj.HoraFinMiercoles = TimeSpan.Parse(txtHoraFinMiercoles.Value);
                obj.HoraFinJueves = TimeSpan.Parse(txtHoraFinJueves.Value);
                obj.HoraFinViernes = TimeSpan.Parse(txtHoraFinViernes.Value);
                obj.HoraFinSabado = TimeSpan.Parse(txtHoraFinSabado.Value);
                obj.HoraFinDomingo = TimeSpan.Parse(txtHoraFinDomingo.Value);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    string filePath = "";
                    string rutaArchivo = ConfigurationManager.AppSettings["RutaArchivos"].ToString();

                    if (fnImagen.HasFile)
                    {
                        if (validarTamaño(fnImagen.FileBytes.Length))
                        {

                            filePath = "/ImagenesEstablecimientos/" + obj.Id + "/" + fnImagen.FileName;
                            string rutaInterna = Server.MapPath(filePath);
                            if (!Directory.Exists(System.IO.Path.GetDirectoryName(rutaInterna)))
                                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(rutaInterna));
                            fnImagen.SaveAs(Server.MapPath(filePath));
                            rutaArchivo = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath;
                        }
                        else
                        {
                            ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                            return;
                        }
                    }
                    else
                    {
                        filePath = hdnFileImage.Value;
                        rutaArchivo = filePath;
                    }
                    obj.Imagen = rutaArchivo;
                    business.Update(obj);

                    UsuarioEstablecimiento model = new UsuarioEstablecimientoCliente(llave).ConsultarUsuarioEstablecimientoByIdEstablecimiento(obj.Id);
                    UsuarioModel usuario = new UsuarioCliente(llave).GetById(model.IdUsuario);
                    usuario.Nombres = obj.Nombre;
                    usuario.Apellidos = "";
                    usuario.Correo = txtCorreo.Value;
                    usuario.UserLogin = txtDocumento.Text;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                    usuario.Estado = true;
                    new UsuarioCliente(llave).Update(usuario);
                }
                else
                {
                    EstablecimientoModel esta = new EstablecimientoCliente(llave).GetByCorreo(txtCorreo.Value).FirstOrDefault();

                    if (esta != null)
                    {
                        if (esta.Estado == true)
                            ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, exite un establecimiento activo creado con el correo " + esta.Correo, null, "error");
                        else
                            ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, exite un establecimiento inactivo creado con el correo " + esta.Correo, null, "error");
                        return;
                    }
                    else
                    {
                        if (fnImagen.HasFile)
                        {
                            if (validarTamaño(fnImagen.FileBytes.Length))
                            {
                                obj = business.Create(obj);
                            }
                            else
                            {
                                ltScripts.Text = Business.Utils.MessageBox("Atención", "El tamaño de la foto supera los " + System.Configuration.ConfigurationManager.AppSettings["tamañoArchivosReal"].ToString() + " kb", null, "error");
                                return;
                            }
                        }

                        if (obj.Id > 0)
                        {
                            string filePath = "";
                            string rutaArchivo = ConfigurationManager.AppSettings["RutaArchivos"].ToString();

                            if (fnImagen.HasFile)
                            {
                                filePath = "/ImagenesEstablecimientos/" + obj.Id + "/" + fnImagen.FileName;
                                string rutaInterna = Server.MapPath("/Archivos" + filePath);
                                if (!Directory.Exists(System.IO.Path.GetDirectoryName(rutaInterna)))
                                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(rutaInterna));
                                fnImagen.SaveAs(rutaInterna);
                            }
                            else
                            {
                                filePath = hdnFileImage.Value;
                            }

                            obj.Imagen = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + filePath;
                            business.Update(obj);

                            string hash = "";
                            UsuarioModel usuario = new UsuarioModel();
                            usuario.IdTipoUsuario = 2;
                            usuario.Nombres = obj.Nombre;
                            usuario.Apellidos = "";
                            usuario.Correo = txtCorreo.Value;
                            usuario.UserLogin = txtDocumento.Text;
                            int longitud = 7;
                            Guid miGuid = Guid.NewGuid();
                            string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
                            hash = RationalSWUtils.Criptography.GetSHA512(token);
                            int idUsuario = 0;
                            usuario.PasswordLogin = hash;
                            usuario.Telefono = txtTelefono.Text;
                            usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                            usuario.Estado = true;
                            usuario.FechaRegistro = DateTime.Now;
                            idUsuario = new UsuarioCliente(llave).Create(usuario).ID;
                            UsuarioEstablecimiento model = new UsuarioEstablecimiento();
                            model.IdEstablecimiento = obj.Id;
                            model.IdUsuario = idUsuario;
                            model.Estado = true;
                            new UsuarioEstablecimientoCliente(llave).Create(model);

                            new Business.EmailBussines().SendMailCreateUserEst(txtDocumento.Text, token, obj.Nombre, txtCorreo.Value);
                        }
                        else
                        {
                            guardado = 0;
                        }
                    }
                }
                if (guardado == 0)
                {
                    ltScripts.Text = Business.Utils.MessageBox("Atención", "Hay un establecimiento creado con la misma información, por favor verifique la información e intente nuevamente", null, "error");
                }
                else
                    ltScripts.Text = Business.Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "EstablecimientoList.aspx", "success");
            }
            catch (Exception ex)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EstablecimientoList.aspx");
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

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            UsuarioCliente usuarioBusiness = new UsuarioCliente(llave);

            UsuarioEstablecimiento model = new UsuarioEstablecimientoCliente(llave).ConsultarUsuarioEstablecimientoByIdEstablecimiento(int.Parse(lbId.Text));

            UsuarioModel usuario = usuarioBusiness.GetById(model.IdUsuario);
            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            usuario.PasswordLogin = Business.Utils.GetSHA512(token);
            usuarioBusiness.CambioClave(usuario);

            new Business.EmailBussines().SendMailCreateUserEst(txtDocumento.Text, token, txtNombre.Text, txtCorreo.Value);
            ltScripts.Text = Business.Utils.MessageBox("Atención", "Se ha enviado el correo de notificación a " + txtCorreo.Value, "EstablecimientoList.aspx", "success");

        }

        public bool validarTamaño(int tamaño)
        {
            if (tamaño > int.Parse(System.Configuration.ConfigurationManager.AppSettings["tamañoArchivos"].ToString())) return false; else return true;
        }

        public void CambioEstado(int id)
        {
            try
            {
                new EstablecimientoCliente(llave).CambiarEstadoEstablecimiento(id);
                ltScripts.Text = Business.Utils.MessageBox("Atención", "El cambio de estado se realizo exitósamente", "EstablecimientoList.aspx", "success");
            }
            catch (Exception ex)
            {
                ltScripts.Text = Business.Utils.MessageBox("Atención", ex.Message, null, "error");
            }

        }

    }
}
