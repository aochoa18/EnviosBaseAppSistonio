using eCommerceSE.Model;
using System;

namespace ClienteBackend
{
    public class Establecimiento
    {
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public ResponsableModel IdResponsable { get; set; }
        public decimal? GeoLat { get; set; }
        public decimal? GeoLon { get; set; }
        public string Direccion { get; set; }
        public decimal Distancia { get; set; }
        public MunicipioModel IdMunicipio { get; set; }
        public DepartamentoModel IdDepto { get; set; }
        public PaisModel IdPais { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
        public int? IdUsuarioRegistra { get; set; }
        public string Imagen { get; set; }
        public CategoriaEstablecimientoModel IdCategoria { get; set; }
        public string Horario { get; set; }
        public string HorarioStatus { get; set; }
    }
}
