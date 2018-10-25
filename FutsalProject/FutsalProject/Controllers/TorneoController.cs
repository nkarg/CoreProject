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
    public class TorneoController : Controller
    {
        private readonly ITorneoManager _torneoManager;

        public TorneoController(ITorneoManager torneoManager)
        {
            _torneoManager = torneoManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = new TorneoViewModel();
            var query = _torneoManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.Nombre = query.Nombre;
                model.IdPrimeraRonda = query.IdPrimeraRonda;
                model.IdSegundaRonda = query.IdSegundaRonda;
                model.IdTerceraRonda = query.IdTerceraRonda;
                model.TiempoDeJuego = query.TiempoDeJuego;
                model.FechaCreacion = query.FechaCreacion;
                model.Borrado = query.Borrado;
            }  

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TorneoViewModel torneo)
        {
            if (ModelState.IsValid)
            {
                var tn = new TorneoEntity
                {
                    Id = torneo.Id,
                    Nombre = torneo.Nombre,
                    IdPrimeraRonda = torneo.IdPrimeraRonda,
                    IdSegundaRonda = torneo.IdSegundaRonda,
                    IdTerceraRonda = torneo.IdTerceraRonda,
                    TiempoDeJuego = torneo.TiempoDeJuego,
                    FechaCreacion = torneo.FechaCreacion,
                    Borrado = torneo.Borrado,
            };

                ViewBag.ResultEntity = _torneoManager.Add(tn);
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = new TorneoViewModel();
            var query = _torneoManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.Nombre = query.Nombre;
                model.IdPrimeraRonda = query.IdPrimeraRonda;
                model.IdSegundaRonda = query.IdSegundaRonda;
                model.IdTerceraRonda = query.IdTerceraRonda;
                model.TiempoDeJuego = query.TiempoDeJuego;
                model.FechaCreacion = query.FechaCreacion;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TorneoViewModel torneo)
        {
            if (ModelState.IsValid)
            {
                var tn = new TorneoEntity
                {
                    Id = torneo.Id,
                    Nombre = torneo.Nombre,
                    IdPrimeraRonda = torneo.IdPrimeraRonda,
                    IdSegundaRonda = torneo.IdSegundaRonda,
                    IdTerceraRonda = torneo.IdTerceraRonda,
                    TiempoDeJuego = torneo.TiempoDeJuego,
                    FechaCreacion = torneo.FechaCreacion,
                    Borrado = torneo.Borrado,
            };

                ViewBag.ResultEntity = _torneoManager.Update(tn);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new TorneoViewModel();
            var query = _torneoManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.Nombre = query.Nombre;
                model.IdPrimeraRonda = query.IdPrimeraRonda;
                model.IdSegundaRonda = query.IdSegundaRonda;
                model.IdTerceraRonda = query.IdTerceraRonda;
                model.TiempoDeJuego = query.TiempoDeJuego;
                model.FechaCreacion = query.FechaCreacion;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TorneoViewModel torneo)
        {
            ViewBag.ResultEntity = _torneoManager.Delete(torneo.Id);
            return View();
        }

        public IActionResult GetAll()
        {
            var model = (from tn in _torneoManager.GetAll()
                         select new TorneoViewModel
                         {
                             Id = tn.Id,
                             Nombre = tn.Nombre,
                             IdPrimeraRonda = tn.IdPrimeraRonda,
                             IdSegundaRonda = tn.IdSegundaRonda,
                             IdTerceraRonda = tn.IdTerceraRonda,
                             TiempoDeJuego = tn.TiempoDeJuego,
                             FechaCreacion = tn.FechaCreacion,
                             Borrado = tn.Borrado,
                         });
            return View(model);
        }

        /// <summary>
        /// Método usada por DataTables
        /// </summary>
        /// <returns></returns>
        public string GetTorneos()
        {
            return JsonConvert.SerializeObject(_torneoManager.GetAll());
        }
    }
}