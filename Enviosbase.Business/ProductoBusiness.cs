
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class ProductoBusiness
    {
        public ProductoModel Create(ProductoModel item)
        {
            return new ProductoDataMapper().Create(item);
        }

        public void Update(ProductoModel item)
        {
            ProductoDataMapper ProductoDM = new ProductoDataMapper();
            ProductoDM.Update(item);
        }

        public List<ProductoModel> GetAll()
        {
            return new ProductoDataMapper().GetAll();
        }

        public ProductoModel GetById(int Id)
        {
            return new ProductoDataMapper().GetById(Id);
        }


        public List<ProductoModel> GetByCategoriaProducto(int IdCategoria)
        {
            return new ProductoDataMapper().GetByCategoriaProducto(IdCategoria);
        }

        public List<ProductoModel> GetByEstablecimiento(int IdEstablecimiento)
        {
            return new ProductoDataMapper().GetByEstablecimiento(IdEstablecimiento);
        }

    }
}

