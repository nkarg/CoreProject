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
                             Id = jg.Id,
                             Dni = jg.Dni,
                             Nombres = jg.Nombres,
                             Apellidos = jg.Apellidos,
                             Direccion = jg.Direccion,
                             Telefono = jg.Telefono,
                             TelefonoEmergencia = jg.TelefonoEmergencia,
                             FotoUrl = jg.FotoUrl,
                             IdPieHabil = jg.IdPieHabil,
                             FechaAfiliacion = jg.FechaAfiliacion,
                             FechaNacimiento = jg.FechaNacimiento,
                             Borrado = jg.Borrado
                         }).ToList();

            return query;
        }

        public JugadorEntity GetById(int id)
        {
            JugadorEntity jugador = null;
            var obj = _repository.GetByKey(id);
            if (obj != null)
            {
                jugador = new JugadorEntity
                {
                    Id = obj.Id,
                    Dni = obj.Dni,
                    Nombres = obj.Nombres,
                    Apellidos = obj.Apellidos,
                    Direccion = obj.Direccion,
                    Telefono = obj.Telefono,
                    TelefonoEmergencia = obj.TelefonoEmergencia,
                    FotoUrl = obj.FotoUrl,
                    IdPieHabil = obj.IdPieHabil,
                    FechaAfiliacion = obj.FechaAfiliacion,
                    FechaNacimiento = obj.FechaNacimiento,
                    Borrado = obj.Borrado
                };
            }

            return jugador;
        }

        public ResultEntity Add(JugadorEntity jugador)
        {
            var result = new ResultEntity();

            var jg = new Jugador
            {
                Dni = jugador.Dni,
                Nombres = jugador.Nombres,
                Apellidos = jugador.Apellidos,
                Direccion = jugador.Direccion,
                Telefono = jugador.Telefono,
                TelefonoEmergencia = jugador.TelefonoEmergencia,
                FotoUrl = jugador.FotoUrl,
                IdPieHabil = jugador.IdPieHabil,
                FechaAfiliacion = jugador.FechaAfiliacion,
                FechaNacimiento = jugador.FechaNacimiento,
                Borrado = jugador.Borrado
            };

            var repResult = _repository.Add(jg);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Jugador añadido con exito." : "Error al añadir un nuevo Jugador.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }
        
        public ResultEntity Update(JugadorEntity jugador)
        {
            var result = new ResultEntity();

            var jg = new Jugador
            {
                Id = jugador.Id,
                Dni = jugador.Dni,
                Nombres = jugador.Nombres,
                Apellidos = jugador.Apellidos,
                Direccion = jugador.Direccion,
                Telefono = jugador.Telefono,
                TelefonoEmergencia = jugador.TelefonoEmergencia,
                FotoUrl = jugador.FotoUrl,
                IdPieHabil = jugador.IdPieHabil,
                FechaAfiliacion = jugador.FechaAfiliacion,
                FechaNacimiento = jugador.FechaNacimiento,
                Borrado = jugador.Borrado
            };

            var repResult = _repository.Update(jg);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Jugador añadido con exito." : "Error al añadir un nuevo Jugador.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }

        public ResultEntity Delete(int id)
        {
            var result = new ResultEntity();

            var jg = _repository.GetByKey(id);

            var repResult = _repository.Delete(jg);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Jugador eliminado con exito." : $"Error al eliminar el Jugador ID: {jg.Id} - {jg.Apellidos}, {jg.Nombres}.";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }
    }
}
