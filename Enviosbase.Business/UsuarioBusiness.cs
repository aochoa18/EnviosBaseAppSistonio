
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class UsuarioBusiness
    {
        public UsuarioModel Create(UsuarioModel item)
        {
            return new UsuarioDataMapper().Create(item);
        }

        public void Update(UsuarioModel item)
        {
            UsuarioDataMapper UsuarioDM = new UsuarioDataMapper();
            UsuarioDM.Update(item);
        }

        public void CambioClave(UsuarioModel item)
        {
            UsuarioDataMapper UsuarioDM = new UsuarioDataMapper();
            UsuarioDM.CambioClave(item);
        }

        public List<UsuarioModel> GetAll()
        {
            return new UsuarioDataMapper().GetAll();
        }

        public UsuarioModel GetById(int ID)
        {
            return new UsuarioDataMapper().GetById(ID);
        }


        public List<UsuarioModel> GetByTipoUsuario(int IdTipoUsuario)
        {
            return new UsuarioDataMapper().GetByTipoUsuario(IdTipoUsuario);
        }

    }
}

