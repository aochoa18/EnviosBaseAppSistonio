namespace ClienteBackend
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public int? idPais { get; set; }
        public int? idDepto { get; set; }
        public int? idMunicipio { get; set; }
        public string contrasena { get; set; }
        public bool? estado { get; set; }
    }
}
