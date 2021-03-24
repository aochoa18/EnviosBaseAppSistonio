using eCommerceSE.Cliente;
using eCommerceSE.Model;
using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Web.UI;


namespace Enviosbase.Producto
{
    public partial class ProductoMasivo : System.Web.UI.Page
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

            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            int respuesta = 0;
            string path;

            if (fnArchivoCargue.HasFile)
            {
                if (Path.GetExtension(fnArchivoCargue.FileName) == ".xls" || Path.GetExtension(fnArchivoCargue.FileName) == ".xlsx")
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Archivos/ImagenesProductos/" + Session["IdEstablecimiento"].ToString() + '/'), Path.GetFileName(fnArchivoCargue.FileName));
                        if (!Directory.Exists(Path.GetDirectoryName(path)))
                            Directory.CreateDirectory(Path.GetDirectoryName(path));
                        fnArchivoCargue.SaveAs(path);

                        FileStream stream = new FileStream(path, FileMode.Open);
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        DataSet result = excelReader.AsDataSet();

                        if (fnImagenes.HasFile)
                        {
                            if (Path.GetExtension(fnImagenes.FileName) == ".zip")
                            {
                                string pathImagenes = Path.Combine(Server.MapPath("~/Archivos/ImagenesProductos/"), Path.GetFileName(fnImagenes.FileName));
                                string pathFinal = Path.Combine(Server.MapPath("~/Archivos/ImagenesProductos/" + Session["IdEstablecimiento"].ToString() + '/'));
                                if (!Directory.Exists(Path.GetDirectoryName(pathImagenes)))
                                    Directory.CreateDirectory(Path.GetDirectoryName(pathImagenes));
                                fnImagenes.SaveAs(pathImagenes);
                                ZipFile.ExtractToDirectory(pathImagenes, pathFinal);
                                File.Delete(pathImagenes);
                                respuesta = 2;
                            }
                            else
                            {
                                respuesta = 1;
                            }
                        }

                        int idUsuario = int.Parse(Session["IdUsuario"].ToString());
                        string rutaArchivo = ConfigurationManager.AppSettings["RutaArchivos"].ToString() + "ImagenesProductos/" + Session["IdEstablecimiento"].ToString() + '/';
                        ProductoCliente cliente = new ProductoCliente(llave);
                        ProductoModel obj = new ProductoModel();
                        var list = ObtenerObjeto(result, rutaArchivo, idUsuario, int.Parse(Session["IdEstablecimiento"].ToString()));
                        File.Delete(path);

                        foreach (ProductoModel item in list)
                        {
                            cliente.Create(item);
                        }
                        if (respuesta == 0 || respuesta == 2)
                        {
                            ltScripts.Text = Business.Utils.MessageBox("", "El arhivo se ha guardado exitosamente", "ProductoList.aspx", "success");
                        }
                        else
                        {
                            ltScripts.Text = Business.Utils.MessageBox("Atención", "El archivo de imagenes no tiene el formato adecuado, se cargo el archivo de productos pero debe reintentar cargar las imagenes", null, "warning");
                        }
                    }
                    catch (Exception ex)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", ex.Message, null, "error");
                    }
                }
            }
            if (fnImagenes.HasFile && respuesta == 0)
            {
                if (Path.GetExtension(fnImagenes.FileName) == ".zip")
                {
                    try
                    {
                        string pathImagenes = Path.Combine(Server.MapPath("~/Archivos/ImagenesProductos/" + Session["IdEstablecimiento"].ToString() + '/'), Path.GetFileName(fnImagenes.FileName));
                        string pathImagenes2 = Path.Combine(Server.MapPath("~/Archivos/ImagenesProductos/" + Session["IdEstablecimiento"].ToString() + '/'));
                        if (!Directory.Exists(Path.GetDirectoryName(pathImagenes)))
                            Directory.CreateDirectory(Path.GetDirectoryName(pathImagenes));
                        fnImagenes.SaveAs(pathImagenes);
                        ZipFile.ExtractToDirectory(pathImagenes, pathImagenes2);
                        File.Delete(pathImagenes);

                        ltScripts.Text = Business.Utils.MessageBox("", "El arhivo se ha guardado exitosamente", "ProductoList.aspx", "success");

                    }
                    catch (Exception ex)
                    {
                        ltScripts.Text = Business.Utils.MessageBox("Atención", "Se presento un error al cargar el archivo, es posible que ya haya guardado un archivo con el mismo nombre anteriormente", null, "warning");
                    }
                }
                else
                {
                    ltScripts.Text = Business.Utils.MessageBox("Atención", "El archivo de imagenes no tiene el formato adecuado", null, "warning");
                }
            }
        }

        public List<ProductoModel> ObtenerObjeto(DataSet result, string rutaArchivo, int idUsuario, int idEstablecimiento)
        {
            List<ProductoModel> paquete = new List<ProductoModel>();
            foreach (DataRow data in result.Tables[0].Rows)
            {
                paquete.Add(new ProductoModel
                {
                    Nombre = data[0].ToString(),
                    Descripcion = data[1].ToString(),
                    Presentacion = data[2].ToString(),
                    Precio = double.Parse(data[3].ToString()),
                    Imagen = rutaArchivo + data[4].ToString(),
                    IdCategoria = int.Parse(data[5].ToString()),
                    CodigoSKU = data[6].ToString(),
                    Codigo = data[7].ToString(),
                    PrecioPromocion = double.Parse(data[8].ToString()),
                    PorcentajePromocion = double.Parse(data[9].ToString()),
                    IdEstablecimiento = idEstablecimiento,
                    IdUsuarioRegistro = idUsuario,
                    Estado = true,
                });
            }
            return paquete;
        }

    }
}