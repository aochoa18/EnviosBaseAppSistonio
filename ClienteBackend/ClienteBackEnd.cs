using eCommerceSE.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClienteBackend
{
    public class ClienteBackEnd : ClienteBase
    {
        public ClienteModel Login(string Login, string Password, string Type)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            LoginModel objectLogin = new LoginModel
            {
                username = Login,
                password = Password,
                type = int.Parse(Type)
            };
            ModelRespuesta mr = ConsumirPorPost("Login", param, objectLogin);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<ClienteModel>(mr.Value);
        }

        public List<CategoriaEstablecimientoModel> GetCategories()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            ModelRespuesta mr = ConsumirPorPost("GetCategorias", param, null);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<List<CategoriaEstablecimientoModel>>(mr.Value);
        }

        public List<Establecimiento> GetEstablecimientosByCategoria(int id, string lat, string lon, int distancia)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                id = id,
                latitud = lat,
                longitud = lon,
                distancia = distancia
            };
            ModelRespuesta mr = ConsumirPorPost("GetEstablecimientosByCategoria", param, model);
            if (mr.Value == null)
                return null;
            else
            {
                return JsonConvert.DeserializeObject<List<Establecimiento>>(mr.Value);
            }
        }

        public List<CategoriaProductoModel> GetCategoriaProductoByEstablecimiento(int IdEstablecimiento)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                id = IdEstablecimiento
            };
            ModelRespuesta mr = ConsumirPorPost("GetCategoriaProductoByEstablecimiento", param, model);
            if (mr.Value == null)
                return null;
            else
            {
                return JsonConvert.DeserializeObject<List<CategoriaProductoModel>>(mr.Value);
            }
        }

        public List<ProductoModel> GetProductosByEstablecimientoCategoria(int IdEstablecimiento, int IdCategoria)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                id = IdEstablecimiento
            };
            ModelRespuesta mr = ConsumirPorPost("GetCategoriaProductoByEstablecimiento", param, model);
            if (mr.Value == null)
                return null;
            else
            {
                List<CategoriaProducto> cats = JsonConvert.DeserializeObject<List<CategoriaProducto>>(mr.Value);
                return cats.Where(x => x.id == IdCategoria).FirstOrDefault().productos;
            }
        }

        public string EnviarMensajeConfirmacion(string phone)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            Random rdn = new Random();
            string code = "";
            for (int i = 0; i < 5; i++)
                code += rdn.Next(9);

            object model = new
            {
                phoneNumber = phone,
                otp = code
            };
            ModelRespuesta mr = ConsumirPorPost("RequestOTP", param, model);
            return code;
        }

        public Cliente CrearCliente(Cliente cliente)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                usuario = JsonConvert.SerializeObject(cliente)
            };
            ModelRespuesta mr = ConsumirPorPost("CrearCliente", param, model);
            if (mr.Value == null)
                throw new Exception(mr.Message);
            else
            {
                return JsonConvert.DeserializeObject<Cliente>(mr.Value);
            }
        }

        public Cliente GetCliente(int IdCliente)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                idUsuario = IdCliente
            };
            ModelRespuesta mr = ConsumirPorPost("GetCliente", param, model);
            if (mr.Value == null)
                throw new Exception(mr.Message);
            else
            {
                return JsonConvert.DeserializeObject<Cliente>(mr.Value);
            }
        }

        public DomiciliarioModel GetDomiciliario(int IdDomiciliario)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                idUsuario = IdDomiciliario
            };
            ModelRespuesta mr = ConsumirPorPost("GetDomiciliario", param, model);
            if (mr.Value == null)
                throw new Exception(mr.Message);
            else
            {
                return JsonConvert.DeserializeObject<DomiciliarioModel>(mr.Value);
            }
        }

        public PedidoModel GetPedidosDomiciliario(int IdDomiciliario)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                idUsuario = IdDomiciliario
            };
            ModelRespuesta mr = ConsumirPorPost("GetDomiciliario", param, model);
            if (mr.Value == null)
                throw new Exception(mr.Message);
            else
            {
                return JsonConvert.DeserializeObject<PedidoModel>(mr.Value);
            }
        }

        public List<PedidoCliente> GetPedidosCliente(int IdCliente)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                idUsuario = IdCliente
            };
            ModelRespuesta mr = ConsumirPorPost("GetPedidosCliente", param, model);
            if (mr.Value == null)
                throw new Exception(mr.Message);
            else
            {
                return JsonConvert.DeserializeObject<List<PedidoCliente>>(mr.Value);
            }
        }


        public string ActualizarCliente(Cliente cliente)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                usuario = JsonConvert.SerializeObject(cliente)
            };
            ModelRespuesta mr = ConsumirPorPost("UpdateCliente", param, model);
            return mr.Message;
        }

        public PedidoCliente CrearPedidoCliente(PedidoFinal pedidoFinal)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                pedido = JsonConvert.SerializeObject(pedidoFinal)
            };
            ModelRespuesta mr = ConsumirPorPost("CrearPedidoCliente", param, model);
            return JsonConvert.DeserializeObject<PedidoCliente>(mr.Value);
        }

        public PedidoCliente UpdatePedidoCliente(PedidoFinal pedidoFinal)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                pedido = JsonConvert.SerializeObject(pedidoFinal)
            };
            ModelRespuesta mr = ConsumirPorPost("UpdatePedidoCliente", param, model);
            return JsonConvert.DeserializeObject<PedidoCliente>(mr.Value);
        }

        public PedidoCliente GetPedido(int IdPedido)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                id = IdPedido
            };
            ModelRespuesta mr = ConsumirPorPost("GetPedido", param, model);
            return JsonConvert.DeserializeObject<PedidoCliente>(mr.Value);
        }

        public List<ProductoModel> GetProductosByNombre(string nombre)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                nombre = nombre
            };
            ModelRespuesta mr = ConsumirPorPost("GetProductosByName", param, model);
            return JsonConvert.DeserializeObject<List<ProductoModel>>(mr.Value);
        }

        public bool UpdatePagoCliente(PagoModel pago)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                pago = JsonConvert.SerializeObject(new
                {
                    id = pago.id,
                    transactionId = pago.TransactionId,
                    valor = pago.Valor,
                    estadoTransaccion = pago.EstadoTransaccion,
                    fechaCreacion = pago.FechaCreacion,
                    fechaRespuesta = pago.FechaRespuesta,
                    idPedido = pago.idPedido,
                    idMedioPago = new
                    {
                        id = pago.IdMedioPago
                    }
                })
            };
            ModelRespuesta mr = ConsumirPorPost("UpdatePagoCliente", param, model);
            return (mr.Type == 0);
        }

        public bool RecoverPwdCliente(string email)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                email = email
            };
            ModelRespuesta mr = ConsumirPorPost("RecoverPwdCliente", param, model);
            if (mr.Value == null)
                throw new Exception(mr.Message);
            else
                return JsonConvert.DeserializeObject<bool>(mr.Value);
        }
    }

    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public int type { get; set; }
    }

}
