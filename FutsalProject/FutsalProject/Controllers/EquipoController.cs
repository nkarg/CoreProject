using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Entities;
using FutsalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FutsalProject.Controllers
{
    public class EquipoController : Controller
    {
        private readonly IEquipoManager _equipoManager;

        public EquipoController(IEquipoManager equipoManager)
        {
            _equipoManager = equipoManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = new EquipoViewModel();
            var query = _equipoManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.NombreLargo = query.NombreLargo;
                model.NombreCorto = query.NombreCorto;
                model.EscudoUrl = query.EscudoUrl;
                model.FechaAfiliacion = query.FechaAfiliacion;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EquipoViewModel equipo)
        {
            if (ModelState.IsValid)
            {
                var eq = new EquipoEntity
                {
                    Id = equipo.Id,
                    NombreLargo = equipo.NombreLargo,
                    NombreCorto = equipo.NombreCorto,
                    EscudoUrl = equipo.EscudoUrl,
                    FechaAfiliacion = equipo.FechaAfiliacion,
                    Borrado = equipo.Borrado
                };

                ViewBag.ResultEntity = _equipoManager.Add(eq);
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = new EquipoViewModel();
            var query = _equipoManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.NombreLargo = query.NombreLargo;
                model.NombreCorto = query.NombreCorto;
                model.EscudoUrl = query.EscudoUrl;
                model.FechaAfiliacion = query.FechaAfiliacion;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EquipoViewModel equipo)
        {
            if (ModelState.IsValid)
            {
                var eq = new EquipoEntity
                {
                    Id = equipo.Id,
                    NombreLargo = equipo.NombreLargo,
                    NombreCorto = equipo.NombreCorto,
                    EscudoUrl = equipo.EscudoUrl,
                    FechaAfiliacion = equipo.FechaAfiliacion,
                    Borrado = equipo.Borrado
                };

                ViewBag.ResultEntity = _equipoManager.Update(eq);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new EquipoViewModel();
            var query = _equipoManager.GetById(id);

            if (query != null)
            {
                model.Id = query.Id;
                model.NombreLargo = query.NombreLargo;
                model.NombreCorto = query.NombreCorto;
                model.EscudoUrl = query.EscudoUrl;
                model.FechaAfiliacion = query.FechaAfiliacion;
                model.Borrado = query.Borrado;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(EquipoViewModel Equipo)
        {
            ViewBag.ResultEntity = _equipoManager.Delete(Equipo.Id);
            return View();
        }

        public IActionResult GetAll()
        {
            var model = (from eq in _equipoManager.GetAll()
                         select new EquipoViewModel
                         {
                             Id = eq.Id,
                             NombreLargo = eq.NombreLargo,
                             NombreCorto = eq.NombreCorto,
                             EscudoUrl = eq.EscudoUrl,
                             FechaAfiliacion = eq.FechaAfiliacion,
                             Borrado = eq.Borrado
                         });
            return View(model);
        }

        /// <summary>
        /// Método usada por DataTables
        /// </summary>
        /// <returns></returns>
        public string GetEquipos()
        {
            return JsonConvert.SerializeObject(_equipoManager.GetAll());
        }
    }
}