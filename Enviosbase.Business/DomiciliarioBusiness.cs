
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class DomiciliarioBusiness
    {
        public int Create(DomiciliarioModel item)
        {            
           return new DomiciliarioDataMapper().Create(item);
        }

        public void Update(DomiciliarioModel item)
        {
            DomiciliarioDataMapper DomiciliarioDM = new DomiciliarioDataMapper();
            DomiciliarioDM.Update(item);
        }

        public List<DomiciliarioModel> GetAll()
        {
            return new DomiciliarioDataMapper().GetAll();
        }

        public DomiciliarioModel GetById(int Id)
        {
            return new DomiciliarioDataMapper().GetById(Id);
        }

        
        public List<DomiciliarioModel> GetByPais(int IdPais)
        {
            return new DomiciliarioDataMapper().GetByPais(IdPais);
        }

        public List<DomiciliarioModel> GetByDepartamento(int IdDepto)
        {
            return new DomiciliarioDataMapper().GetByDepartamento(IdDepto);
        }

        public List<DomiciliarioModel> GetByMunicipio(int IdMunicipio)
        {
            return new DomiciliarioDataMapper().GetByMunicipio(IdMunicipio);
        }

        public List<DomiciliarioModel> GetByTipoVehiculo(int IdTipoVehiculo)
        {
            return new DomiciliarioDataMapper().GetByTipoVehiculo(IdTipoVehiculo);
        }

        public List<DomiciliarioModel> GetByMarca(int IdMarca)
        {
            return new DomiciliarioDataMapper().GetByMarca(IdMarca);
        }

    }
}

