
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class PaisBusiness
    {
        public int Create(PaisModel item)
        {           
           return new PaisDataMapper().Create(item);
        }

        public void Update(PaisModel item)
        {
            PaisDataMapper PaisDM = new PaisDataMapper();
            PaisDM.Update(item);
        }

        public List<PaisModel> GetAll()
        {
            return new PaisDataMapper().GetAll();
        }

        public PaisModel GetById(int Id)
        {
            return new PaisDataMapper().GetById(Id);
        }

        
    }
}

