
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class TipoUsuarioBusiness
    {
        public int Create(TipoUsuarioModel item)
        {           
           return new TipoUsuarioDataMapper().Create(item);
        }

        public void Update(TipoUsuarioModel item)
        {
            TipoUsuarioDataMapper TipoUsuarioDM = new TipoUsuarioDataMapper();
            TipoUsuarioDM.Update(item);
        }

        public List<TipoUsuarioModel> GetAll()
        {
            return new TipoUsuarioDataMapper().GetAll();
        }

        public TipoUsuarioModel GetById(int Id)
        {
            return new TipoUsuarioDataMapper().GetById(Id);
        }

        
    }
}

