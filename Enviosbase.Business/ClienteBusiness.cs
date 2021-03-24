
using Enviosbase.Data;
using Enviosbase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviosbase.Business
{ 
    public class ClienteBusiness
    {
        public int Create(ClienteModel item)
        {           
           return new ClienteDataMapper().Create(item);
        }

        public void Update(ClienteModel item)
        {
            ClienteDataMapper ClienteDM = new ClienteDataMapper();
            ClienteDM.Update(item);
        }

        public List<ClienteModel> GetAll()
        {
            return new ClienteDataMapper().GetAll();
        }

        public ClienteModel GetById(int Id)
        {
            return new ClienteDataMapper().GetById(Id);
        }

        
        public List<ClienteModel> GetByPais(int IdPais)
        {
            return new ClienteDataMapper().GetByPais(IdPais);
        }

        public List<ClienteModel> GetByDepartamento(int IdDepto)
        {
            return new ClienteDataMapper().GetByDepartamento(IdDepto);
        }

        public List<ClienteModel> GetByMunicipio(int IdMunicipio)
        {
            return new ClienteDataMapper().GetByMunicipio(IdMunicipio);
        }

    }
}

