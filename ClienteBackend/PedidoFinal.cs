using eCommerceSE.Model;
using System.Collections.Generic;

namespace ClienteBackend
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class IdCiudad
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class Direccion : DireccionClienteModel
    {
        public bool EsCalculada { get; set; }
        public new IdCiudad IdCiudad { get; set; }
    }

    public class IdPais
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class IdDepto
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class IdMunicipio
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class IdCategoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
    }

    public class EstablecimientoP : EstablecimientoModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public IdPais idPais { get; set; }
        public string direccion { get; set; }
        public double geoLon { get; set; }
        public double geoLat { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public double distancia { get; set; }
        public string FormatedDistance { get; set; }
        public string imagen { get; set; }
        public IdDepto idDepto { get; set; }
        public IdMunicipio idMunicipio { get; set; }
        public IdCategoria idCategoria { get; set; }
    }

    public class Producto
    {
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Presentacion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string CodigoSKU { get; set; }
        public double PrecioPromocion { get; set; }
        public double PorcentajePromocion { get; set; }
        public string Codigo { get; set; }
        public string PrecioInicial { get; set; }
        public string PrecioDescuento { get; set; }
        public string GetPercentage { get; set; }
    }

    public class PedidoFinal
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public Direccion Direccion { get; set; }
        public object Observaciones { get; set; }
        public string MedioPago { get; set; }
        public string EstadoPedido { get; set; }
        public EstablecimientoP Establecimiento { get; set; }
        public List<Producto> Productos { get; set; }
        public double PrecioTotal { get; set; }
    }
}
