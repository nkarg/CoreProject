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
    public class JugadorManager : IJugadorManager
    {
        private readonly IJugadorRepository _repository;

        public JugadorManager(IJugadorRepository repository)
        {
            _repository = repository;
        }

        public List<JugadorEntity> GetAll()
        {
            var query = (from jg in _repository.GetAll()
                         select new JugadorEntity
                         {
                             Id = jg.Id
                         }).ToList();

            return query;
        }

        public JugadorEntity GetById(int id)
        {
            JugadorEntity jugador = null;
            var obj = _repository.GetByKey(id);
            if (obj != null)
            {
                jugador.Id = obj.Id;
            }

            return jugador;
        }

        public bool Add(JugadorEntity jugador)
        {
            return _repository.Add(new Jugador
            {
                Id = jugador.Id,
                Dni = jugador.Dni,
                Nombres = jugador.Nombres,
                Apellidos = jugador.Apellidos,
                FechaNacimiento = jugador.FechaNacimiento,
                Direccion = jugador.Direccion,
                Telefono = jugador.Telefono,
                TelefonoEmergencia = jugador.TelefonoEmergencia,
                FotoUrl = jugador.FotoUrl,
                IdPieHabil = jugador.IdPieHabil,
                FechaAfiliacion = jugador.FechaAfiliacion,
                Borrado = jugador.Borrado
            });
        }
    }
}
