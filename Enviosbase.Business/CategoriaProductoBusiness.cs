
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class CategoriaProductoBusiness
    {
        public CategoriaProductoModel Create(CategoriaProductoModel item)
        {
            return new CategoriaProductoDataMapper().Create(item);
        }

        public void Update(CategoriaProductoModel item)
        {
            CategoriaProductoDataMapper CategoriaProductoDM = new CategoriaProductoDataMapper();
            CategoriaProductoDM.Update(item);
        }

        public List<CategoriaProductoModel> GetAll()
        {
            return new CategoriaProductoDataMapper().GetAll();
        }

        public CategoriaProductoModel GetById(int id)
        {
            return new CategoriaProductoDataMapper().GetById(id);
        }


    }
}

