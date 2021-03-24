
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class CategoriaEstablecimientoBusiness
    {
        public CategoriaEstablecimientoModel Create(CategoriaEstablecimientoModel item)
        {
            return new CategoriaEstablecimientoDataMapper().Create(item);
        }

        public void Update(CategoriaEstablecimientoModel item)
        {
            CategoriaEstablecimientoDataMapper CategoriaEstablecimientoDM = new CategoriaEstablecimientoDataMapper();
            CategoriaEstablecimientoDM.Update(item);
        }

        public List<CategoriaEstablecimientoModel> GetAll()
        {
            return new CategoriaEstablecimientoDataMapper().GetAll();
        }

        public CategoriaEstablecimientoModel GetById(int Id)
        {
            return new CategoriaEstablecimientoDataMapper().GetById(Id);
        }


    }
}

