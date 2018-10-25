using Core.Abstract;
using Core.Entities;
using Core.Infraestructure.Custom;
using Data;
using DataRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Concrete
{
    public class EquipoManager: IEquipoManager
    {
        private readonly IEquipoRepository _repository;

        public EquipoManager(IEquipoRepository repository)
        {
            _repository = repository;
        }

        public List<EquipoEntity> GetAll()
        {
            var query = (from eq in _repository.GetAll()
                         select new EquipoEntity
                         {
                             Id = eq.Id,
                             NombreLargo = eq.NombreLargo,
                             NombreCorto = eq.NombreCorto,
                             EscudoUrl = eq.EscudoUrl,
                             FechaAfiliacion = eq.FechaAfiliacion,
                             Borrado = eq.Borrado
                         }).ToList();

            return query;
        }

        public EquipoEntity GetById(int id)
        {
            EquipoEntity Equipo = null;
            var obj = _repository.GetByKey(id);
            if (obj != null)
            {
                Equipo = new EquipoEntity
                {
                    Id = obj.Id,
                    NombreLargo = obj.NombreLargo,
                    NombreCorto = obj.NombreCorto,
                    EscudoUrl = obj.EscudoUrl,
                    FechaAfiliacion = obj.FechaAfiliacion,
                    Borrado = obj.Borrado
                };
            }

            return Equipo;
        }

        public ResultEntity Add(EquipoEntity equipo)
        {
            var result = new ResultEntity();

            var eq = new Equipo
            {
                NombreLargo = equipo.NombreLargo,
                NombreCorto = equipo.NombreCorto,
                EscudoUrl = equipo.EscudoUrl,
                FechaAfiliacion = equipo.FechaAfiliacion,
                Borrado = equipo.Borrado
            };

            var repResult = _repository.Add(eq);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Equipo añadido con exito." : "Error al añadir un nuevo Equipo.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }

        public ResultEntity Update(EquipoEntity equipo)
        {
            var result = new ResultEntity();

            var eq = new Equipo
            {
                Id = equipo.Id,
                NombreLargo = equipo.NombreLargo,
                NombreCorto = equipo.NombreCorto,
                EscudoUrl = equipo.EscudoUrl,
                FechaAfiliacion = equipo.FechaAfiliacion,
                Borrado = equipo.Borrado
            };

            var repResult = _repository.Update(eq);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Equipo añadido con exito." : "Error al añadir un nuevo Equipo.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }

        public ResultEntity Delete(int id)
        {
            var result = new ResultEntity();

            var eq = _repository.GetByKey(id);

            var repResult = _repository.Delete(eq);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Equipo eliminado con exito." : $"Error al eliminar el Equipo ID: {id}).";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }
    }
}
