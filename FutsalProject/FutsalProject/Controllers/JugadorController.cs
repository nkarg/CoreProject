using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entities;
using FutsalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FutsalProject.Controllers
{
    [Authorize]
    public class JugadorController : Controller
    {
        private readonly IJugadorManager _jugadorManager;

        public JugadorController(IJugadorManager jugadorManager)
        {
            _jugadorManager = jugadorManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = new JugadorViewModel();
            var query = _jugadorManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.Dni = query.Dni;
                model.Nombres = query.Nombres;
                model.Apellidos = query.Apellidos;
                model.Direccion = query.Direccion;
                model.Telefono = query.Telefono;
                model.TelefonoEmergencia = query.TelefonoEmergencia;
                model.FotoUrl = query.FotoUrl;
                model.IdPieHabil = query.IdPieHabil;
                model.FechaAfiliacion = query.FechaAfiliacion;
                model.FechaNacimiento = query.FechaNacimiento;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JugadorViewModel jugador)
        {
            if (ModelState.IsValid)
            {
                var jg = new JugadorEntity
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

                ViewBag.ResultEntity = _jugadorManager.Add(jg);
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = new JugadorViewModel();
            var query = _jugadorManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.Dni = query.Dni;
                model.Nombres = query.Nombres;
                model.Apellidos = query.Apellidos;
                model.Direccion = query.Direccion;
                model.Telefono = query.Telefono;
                model.TelefonoEmergencia = query.TelefonoEmergencia;
                model.FotoUrl = query.FotoUrl;
                model.IdPieHabil = query.IdPieHabil;
                model.FechaAfiliacion = query.FechaAfiliacion;
                model.FechaNacimiento = query.FechaNacimiento;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(JugadorViewModel jugador)
        {
            if (ModelState.IsValid)
            {
                var jg = new JugadorEntity
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

                ViewBag.ResultEntity = _jugadorManager.Update(jg);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new JugadorViewModel();
            var query = _jugadorManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.Dni = query.Dni;
                model.Nombres = query.Nombres;
                model.Apellidos = query.Apellidos;
                model.Direccion = query.Direccion;
                model.Telefono = query.Telefono;
                model.TelefonoEmergencia = query.TelefonoEmergencia;
                model.FotoUrl = query.FotoUrl;
                model.IdPieHabil = query.IdPieHabil;
                model.FechaAfiliacion = query.FechaAfiliacion;
                model.FechaNacimiento = query.FechaNacimiento;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(JugadorViewModel jugador)
        {
            ViewBag.ResultEntity = _jugadorManager.Delete(jugador.Id);
            return View();
        }

        public IActionResult GetAll()
        {
            var model = (from jg in _jugadorManager.GetAll()
                         select new JugadorViewModel
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
                         });
            return View(model);
        }

        /// <summary>
        /// Método usada por DataTables
        /// </summary>
        /// <returns></returns>
        public string GetJugadores()
        {
            return JsonConvert.SerializeObject(_jugadorManager.GetAll());
        }
    }
}