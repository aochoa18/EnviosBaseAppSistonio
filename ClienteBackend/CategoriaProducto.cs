using eCommerceSE.Model;
using System.Collections.Generic;

namespace ClienteBackend
{


    public class CategoriaProducto : CategoriaProductoModel
    {
        public List<ProductoModel> productos { get; set; }
    }
}
