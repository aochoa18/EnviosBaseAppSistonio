
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class MarcaBusiness
    {
        public int Create(MarcaModel item)
        {           
           return new MarcaDataMapper().Create(item);
        }

        public void Update(MarcaModel item)
        {
            MarcaDataMapper MarcaDM = new MarcaDataMapper();
            MarcaDM.Update(item);
        }

        public List<MarcaModel> GetAll()
        {
            return new MarcaDataMapper().GetAll();
        }

        public MarcaModel GetById(int Id)
        {
            return new MarcaDataMapper().GetById(Id);
        }

        
    }
}

