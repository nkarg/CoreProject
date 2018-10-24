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
                jugador.Id = obj.Id;
                jugador.Dni = obj.Dni;
                jugador.Nombres = obj.Nombres;
                jugador.Apellidos = obj.Apellidos;
                jugador.Direccion = obj.Direccion;
                jugador.Telefono = obj.Telefono;
                jugador.TelefonoEmergencia = obj.TelefonoEmergencia;
                jugador.FotoUrl = obj.FotoUrl;
                jugador.IdPieHabil = obj.IdPieHabil;
                jugador.FechaAfiliacion = obj.FechaAfiliacion;
                jugador.Borrado = obj.Borrado;
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
                Borrado = jugador.Borrado
            };

            var repResult = _repository.Add(jg);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Jugador añadido con exito." : "Error al añadir un nuevo jugador";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }
        
        public ResultEntity Update(JugadorEntity jugador)
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
                Borrado = jugador.Borrado
            };

            var repResult = _repository.Update(jg);
            result.ResultOk = repResult.ActionResult;
            result.Message = repResult.ActionResult ? "Jugador añadido con exito." : "Error al añadir un nuevo jugador";
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
            result.Message = repResult.ActionResult ? "Jugador eliminado con exito." : $"Error al eliminar el jugador ID: {jg.Id} - {jg.Apellidos}, {jg.Nombres}";
            result.ErrorCode = repResult.ActionResult ? 200 : 500;
            result.ErrorDescription = repResult.Error?.Message;

            return result;
        }
    }
}
