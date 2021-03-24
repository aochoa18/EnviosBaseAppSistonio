using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class TipoVehiculoBusiness
    {
        public int Create(TipoVehiculoModel item)
        {           
           return new TipoVehiculoDataMapper().Create(item);
        }

        public void Update(TipoVehiculoModel item)
        {
            TipoVehiculoDataMapper TipoVehiculoDM = new TipoVehiculoDataMapper();
            TipoVehiculoDM.Update(item);
        }

        public List<TipoVehiculoModel> GetAll()
        {
            return new TipoVehiculoDataMapper().GetAll();
        }

        public TipoVehiculoModel GetById(int Id)
        {
            return new TipoVehiculoDataMapper().GetById(Id);
        }

        
    }
}

