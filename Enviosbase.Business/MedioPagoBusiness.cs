
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class MedioPagoBusiness
    {
        public MedioPagoModel Create(MedioPagoModel item)
        {
            return new MedioPagoDataMapper().Create(item);
        }

        public void Update(MedioPagoModel item)
        {
            MedioPagoDataMapper MedioPagoDM = new MedioPagoDataMapper();
            MedioPagoDM.Update(item);
        }

        public List<MedioPagoModel> GetAll()
        {
            return new MedioPagoDataMapper().GetAll();
        }

        public MedioPagoModel GetById(int Id)
        {
            return new MedioPagoDataMapper().GetById(Id);
        }


    }
}

