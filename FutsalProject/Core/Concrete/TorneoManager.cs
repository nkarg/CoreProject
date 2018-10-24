using Core.Abstract;
using Core.Entities;
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
                             Id = tn.Id
                         }).ToList();

            return query;
        }

        public TorneoEntity GetById(int id)
        {
            TorneoEntity torneo = null;
            var obj = _repository.GetByKey(id);
            if (obj != null)
            {
                torneo.Id = obj.Id;
            }

            return torneo;
        }


        public bool Add(TorneoEntity torneo)
        {
            return _repository.Add(new Torneo
            {
                Id = torneo.Id,
                Nombre = torneo.Nombre,
                IdPrimeraRonda = torneo.IdPrimeraRonda,
                IdSegundaRonda = torneo.IdSegundaRonda,
                IdTerceraRonda = torneo.IdTerceraRonda,
                TiempoDeJuego = torneo.TiempoDeJuego,
                FechaCreacion = torneo.FechaCreacion,
                Borrado = torneo.Borrado
            });
        }
    }
}
