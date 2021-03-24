
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{
    public class DepartamentoBusiness
    {
        public int Create(DepartamentoModel item) 
        {           
           return new DepartamentoDataMapper().Create(item);
        }

        public void Update(DepartamentoModel item)
        {
            DepartamentoDataMapper DepartamentoDM = new DepartamentoDataMapper();
            DepartamentoDM.Update(item);
        }

        public List<DepartamentoModel> GetAll()
        {
            return new DepartamentoDataMapper().GetAll();
        }

        public DepartamentoModel GetById(int Id)
        {
            return new DepartamentoDataMapper().GetById(Id);
        }

        
        public List<DepartamentoModel> GetByPais(int IdPais)
        {
            return new DepartamentoDataMapper().GetByPais(IdPais);
        }

    }
}

