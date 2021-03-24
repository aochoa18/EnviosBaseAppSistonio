using System;
using System.Collections.Generic;

namespace ClienteBackend
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class IdTipoVehiculo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idUsuarioRegistro { get; set; }
    }

    public class IdMarca
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
        public object fechaRegistro { get; set; }
        public int idUsuarioRegistro { get; set; }
    }

    public class IdDomiciliario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string modelo { get; set; }
        public string placa { get; set; }
        public bool estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string userLogin { get; set; }
        public string passwordLogin { get; set; }
        public string correo { get; set; }
        public string imagenDocumento { get; set; }
        public string imagenPase { get; set; }
        public string imagenSoat { get; set; }
        public string imagenTarjetaPropiedad { get; set; }
        public string imagenFoto { get; set; }
        public IdTipoVehiculo idTipoVehiculo { get; set; }
        public IdMarca idMarca { get; set; }
    }

    public class IdEstablecimiento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public double geoLon { get; set; }
        public double geoLat { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public bool estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idUsuarioRegistra { get; set; }
        public string imagen { get; set; }
    }

    public class IdCliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }
    }

    public class IdEstadoPedido
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
        public DateTime fechaRegistro { get; set; }
    }

    public class IdProducto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string presentacion { get; set; }
        public int precio { get; set; }
        public string imagen { get; set; }
        public bool estado { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string codigoSku { get; set; }
        public int precioPromocion { get; set; }
        public int porcentajePromocion { get; set; }
        public string codigo { get; set; }
    }

    public class ProductosPedido
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public bool estado { get; set; }
        public object fechaRegistro { get; set; }
        public int precio { get; set; }
        public IdProducto idProducto { get; set; }
    }

    public class PedidoCliente
    {
        public int id { get; set; }
        public object noPedido { get; set; }
        public string direccion { get; set; }
        public object observaciones { get; set; }
        public DateTime? fechaEntrega { get; set; }
        public string estado { get; set; }
        public DateTime fechaRegistro { get; set; }
        public double geolat { get; set; }
        public double geolon { get; set; }
        public IdDomiciliario idDomiciliario { get; set; }
        public IdCliente idCliente { get; set; }
        public IdEstablecimiento idEstablecimiento { get; set; }
        public IdEstadoPedido idEstadoPedido { get; set; }
        public List<ProductosPedido> productosPedidos { get; set; }
    }
}
