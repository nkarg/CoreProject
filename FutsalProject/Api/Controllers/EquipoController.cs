using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entities;
using Core.Infraestructure.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IEquipoManager _equipoManager;

        public EquipoController(IMemoryCache memoryCache, IEquipoManager equipoManager)
        {
            _memoryCache = memoryCache;
            _equipoManager = equipoManager;
        }

        // GET api/values
        /// <summary>
        /// Obtiene todos los equipos en DDBB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EquipoEntity>> Get()
        {
            var cache = _memoryCache.GetOrCreate("Equipos", entry =>
            {
                return _equipoManager.GetAll();
            });

            return cache;
        }

        // GET api/values/5
        /// <summary>
        /// Obtiene un equipo mediante su ID
        /// </summary>
        /// <param name="id">ID del equipo</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<EquipoEntity> Get(int id)
        {
            var cache = _memoryCache.GetOrCreate("Equipos", entry =>
            {
                return _equipoManager.GetAll();
            });

            var equipo = cache.Find(x => x.Id.Equals(id));
            if(equipo != null)
            {
                return equipo;
            }
           
            return NotFound($"Equipo con ID: {id} no encontrado");
        }

        // POST api/values
        /// <summary>
        /// Modifica un equipo
        /// </summary>
        /// <param name="model">Modelo de la entidad</param>
        [HttpPost]
        public ActionResult<ResultEntity> Post([FromBody] EquipoEntity model)
        {
            return _equipoManager.Update(model);
        }

        // PUT api/values/5
        /// <summary>
        /// Añade un equipo
        /// </summary>
        /// <param name="model">Modelo de la entidad</param>
        [HttpPut]
        public ActionResult<ResultEntity> Put([FromBody] EquipoEntity model)
        {
            return _equipoManager.Add(model);
        }

        // DELETE api/values/5
        /// <summary>
        /// Elimina un equipo mediante su ID
        /// </summary>
        /// <param name="id">ID del equipo</param>
        [HttpDelete("{id}")]
        public ActionResult<ResultEntity> Delete(int id)
        {
            return _equipoManager.Delete(id);
        }
    }
}