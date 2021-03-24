
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class MunicipioBusiness
    {
        public int Create(MunicipioModel item)
        {           
           return new MunicipioDataMapper().Create(item);
        }

        public void Update(MunicipioModel item)
        {
            MunicipioDataMapper MunicipioDM = new MunicipioDataMapper();
            MunicipioDM.Update(item);
        }

        public List<MunicipioModel> GetAll()
        {
            return new MunicipioDataMapper().GetAll();
        }

        public MunicipioModel GetById(int Id)
        {
            return new MunicipioDataMapper().GetById(Id);
        }

        
        public List<MunicipioModel> GetByDepartamento(int IdDepto)
        {
            return new MunicipioDataMapper().GetByDepartamento(IdDepto);
        }

    }
}

