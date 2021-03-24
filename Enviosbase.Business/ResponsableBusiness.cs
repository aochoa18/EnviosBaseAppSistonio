
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class ResponsableBusiness
    {
        public ResponsableModel Create(ResponsableModel item)
        {
            return new ResponsableDataMapper().Create(item);
        }

        public void Update(ResponsableModel item)
        {
            ResponsableDataMapper ResponsableDM = new ResponsableDataMapper();
            ResponsableDM.Update(item);
        }

        public List<ResponsableModel> GetAll()
        {
            return new ResponsableDataMapper().GetAll();
        }

        public ResponsableModel GetById(int Id)
        {
            return new ResponsableDataMapper().GetById(Id);
        }


        public List<ResponsableModel> GetByPais(int IdPais)
        {
            return new ResponsableDataMapper().GetByPais(IdPais);
        }

        public List<ResponsableModel> GetByDepartamento(int IdDepto)
        {
            return new ResponsableDataMapper().GetByDepartamento(IdDepto);
        }

        public List<ResponsableModel> GetByMunicipio(int IdMunicipio)
        {
            return new ResponsableDataMapper().GetByMunicipio(IdMunicipio);
        }

    }
}

