
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class EstadoPedidoBusiness
    {
        public EstadoPedidoModel Create(EstadoPedidoModel item)
        {
            return new EstadoPedidoDataMapper().Create(item);
        }

        public void Update(EstadoPedidoModel item)
        {
            EstadoPedidoDataMapper EstadoPedidoDM = new EstadoPedidoDataMapper();
            EstadoPedidoDM.Update(item);
        }

        public List<EstadoPedidoModel> GetAll()
        {
            return new EstadoPedidoDataMapper().GetAll();
        }

        public EstadoPedidoModel GetById(int Id)
        {
            return new EstadoPedidoDataMapper().GetById(Id);
        }


    }
}

