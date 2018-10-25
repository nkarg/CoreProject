using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IJugadorManager _jugadorManager;

        public JugadorController(IMemoryCache memoryCache, IJugadorManager jugadorManager)
        {
            _memoryCache = memoryCache;
            _jugadorManager = jugadorManager;
        }

        // GET api/values
        /// <summary>
        /// Obtiene todos los jugadores en DDBB
        /// </summary>
        /// <returns code="200">Listado de equipos</returns>
        [HttpGet]
        public ActionResult<List<JugadorEntity>> Get()
        {
            var cache = _memoryCache.GetOrCreate("Jugadores", entry =>
            {
                return _jugadorManager.GetAll();
            });

            return cache;
        }

        // GET api/values/5
        /// <summary>
        /// Obtiene un jugador mediante su ID
        /// </summary>
        /// <param name="id">ID del jugador</param>
        /// <returns code="200">Un jugador específico</returns>
        /// <returns code="404">No se encontro jugador</returns>
        [HttpGet("{id}")]
        public ActionResult<JugadorEntity> Get(int id)
        {
            var cache = _memoryCache.GetOrCreate("Jugadores", entry =>
            {
                return _jugadorManager.GetAll();
            });

            var jugador = cache.Find(x => x.Id.Equals(id));
            if (jugador != null)
            {
                return jugador;
            }

            return NotFound($"Jugador con ID: {id} no encontrado");
        }

        // POST api/values
        /// <summary>
        /// Modifica un jugador
        /// </summary>
        /// <param name="model">Modelo de la entidad</param>
        [HttpPost]
        public void Post([FromBody] JugadorEntity model)
        {
            _jugadorManager.Update(model);
        }

        // PUT api/values/5
        /// <summary>
        /// Añade un jugador
        /// </summary>
        /// <param name="model">Modelo de la entidad</param>
        [HttpPut]
        public void Put([FromBody] JugadorEntity model)
        {
            _jugadorManager.Add(model);
        }

        // DELETE api/values/5
        /// <summary>
        /// Elimina un jugador mediante su ID
        /// </summary>
        /// <param name="id">ID del jugador</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _jugadorManager.Delete(id);
        }
    }
}