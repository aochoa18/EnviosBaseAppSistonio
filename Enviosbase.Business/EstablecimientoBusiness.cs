
using Enviosbase.Data;
using Enviosbase.Model;
using System.Collections.Generic;

namespace Enviosbase.Business
{
    public class EstablecimientoBusiness
    {
        public EstablecimientoModel Create(EstablecimientoModel item)
        {
            return new EstablecimientoDataMapper().Create(item);
        }

        public void Update(EstablecimientoModel item) 
        {
            EstablecimientoDataMapper EstablecimientoDM = new EstablecimientoDataMapper();
            EstablecimientoDM.Update(item);
        }

        public List<EstablecimientoModel> GetAll()
        {
            return new EstablecimientoDataMapper().GetAll();
        }

        public EstablecimientoModel GetById(int Id)
        {
            return new EstablecimientoDataMapper().GetById(Id);
        }


        public List<EstablecimientoModel> GetByPais(int IdPais)
        {
            return new EstablecimientoDataMapper().GetByPais(IdPais);
        }

        public List<EstablecimientoModel> GetByDepartamento(int IdDepto)
        {
            return new EstablecimientoDataMapper().GetByDepartamento(IdDepto);
        }

        public List<EstablecimientoModel> GetByMunicipio(int IdMunicipio)
        {
            return new EstablecimientoDataMapper().GetByMunicipio(IdMunicipio);
        }

        public List<EstablecimientoModel> GetByResponsable(int IdResponsable)
        {
            return new EstablecimientoDataMapper().GetByResponsable(IdResponsable);
        }

        public List<EstablecimientoModel> GetByCategoriaEstablecimiento(int IdCategoria)
        {
            return new EstablecimientoDataMapper().GetByCategoriaEstablecimiento(IdCategoria);
        }

    }
}

