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
    public class TorneoManager : ITorneoManager
    {
        private readonly ITorneoRepository _repository;

        public TorneoManager(ITorneoRepository repository)
        {
            _repository = repository;
        }

        public List<TorneoEntity> GetAll()
        {
            var query = (from tn in _repository.GetAll()
                         select new TorneoEntity
                         {
                              Id = tn.Id,
                              Nombre = tn.Nombre,
                              IdPrimeraRonda = tn.IdPrimeraRonda,
                              IdSegundaRonda = tn.IdSegundaRonda,
                              IdTerceraRonda = tn.IdTerceraRonda,
                              TiempoDeJuego = tn.TiempoDeJuego,
                              FechaCreacion = tn.FechaCreacion,
                              Borrado = tn.Borrado
                        }).ToList();

            return query;
        }

        public TorneoEntity GetById(int id)
        {
            TorneoEntity torneo = null;
            var obj = _repository.GetByKey(id);
            if (obj != null)
            {
                torneo = new TorneoEntity
                {
                    Id = torneo.Id,
                    Nombre = torneo.Nombre,
                    IdPrimeraRonda = torneo.IdPrimeraRonda,
                    IdSegundaRonda = torneo.IdSegundaRonda,
                    IdTerceraRonda = torneo.IdTerceraRonda,
                    TiempoDeJuego = torneo.TiempoDeJuego,
                    FechaCreacion = torneo.FechaCreacion,
                    Borrado = torneo.Borrado
                };
            }

            return torneo;
        }


        public ResultEntity Add(TorneoEntity torneo)
        {
            var result = new ResultEntity();

            var tn = new Torneo
            {
                Id = torneo.Id,
                Nombre = torneo.Nombre,
                IdPrimeraRonda = torneo.IdPrimeraRonda,
                IdSegundaRonda = torneo.IdSegundaRonda,
                IdTerceraRonda = torneo.IdTerceraRonda,
                TiempoDeJuego = torneo.TiempoDeJuego,
                FechaCreacion = torneo.FechaCreacion,
                Borrado = torneo.Borrado
            };

            var repResult = _repository.Add(tn);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Torneo añadido con exito." : "Error al añadir un nuevo Torneo.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }

        public ResultEntity Update(TorneoEntity torneo)
        {
            var result = new ResultEntity();

            var tn = new Torneo
            {
                Id = torneo.Id,
                Nombre = torneo.Nombre,
                IdPrimeraRonda = torneo.IdPrimeraRonda,
                IdSegundaRonda = torneo.IdSegundaRonda,
                IdTerceraRonda = torneo.IdTerceraRonda,
                TiempoDeJuego = torneo.TiempoDeJuego,
                FechaCreacion = torneo.FechaCreacion,
                Borrado = torneo.Borrado
            };

            var repResult = _repository.Update(tn);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Torneo añadido con exito." : "Error al añadir un nuevo Torneo.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }

        public ResultEntity Delete(int id)
        {
            var result = new ResultEntity();

            var tn = _repository.GetByKey(id);

            var repResult = _repository.Delete(tn);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Torneo eliminado con exito." : $"Error al eliminar el Torneo ID: {tn.Id} - {tn.Nombre}.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }
    }
}
