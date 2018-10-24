using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using FutsalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutsalProject.Controllers
{
    public class JugadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
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

            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(JugadorViewModel jugador)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}