using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FutsalProject.Models;
using Core.Abstract;
using Core.Entities;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FutsalProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            #region Conteo de datos

            var client = new HttpClient();

            if(_env.EnvironmentName == "API")
            {
                dynamic objPlayer = new JObject();
                objPlayer.Dni = 34973249;
                objPlayer.Nombres = "Eduardo Alejandro";
                objPlayer.Apellidos = "Rojo Cadenas";
                objPlayer.FechaNacimiento = "23/01/1990";
                objPlayer.Direccion = "Necochea 3148";
                objPlayer.Telefono = "3794801803";
                objPlayer.TelefonoEmergencia = "4434013";
                objPlayer.IdPieHabil = 1;
                objPlayer.FechaAfiliacion = DateTime.Today.ToShortDateString();

                dynamic objTeam = new JObject();
                objTeam.NombreLargo = "Submarino Footballl Club";
                objTeam.NombreCorto = "Submarino";
                objTeam.FechaAfiliacion = DateTime.Today.ToShortDateString();

                var content1 = new StringContent(objPlayer.ToString(), Encoding.UTF8, "application/json");
                var content2 = new StringContent(objTeam.ToString(), Encoding.UTF8, "application/json");

                var responseAddPlayer = await client.PostAsync("https://localhost:44337/api/Jugador", content1);
                var responseAddTeam = await client.PostAsync("https://localhost:44337/api/Partido", content2);

                if (responseAddPlayer.IsSuccessStatusCode)
                {
                    var resp = await responseAddPlayer.Content.ReadAsStringAsync();
                    var json = JObject.Parse(resp);
                }

                if (responseAddTeam.IsSuccessStatusCode)
                {
                    var resp = await responseAddTeam.Content.ReadAsStringAsync();
                    var json = JObject.Parse(resp);
                }
            }
            
            var responseOne = await client.GetAsync("https://localhost:44337/api/Jugador");
            var responseTwo = await client.GetAsync("https://localhost:44337/api/Equipo");
            if (responseOne.IsSuccessStatusCode)
            {
                var lJugadores = await responseOne.Content.ReadAsAsync<List<JugadorEntity>>();

                ViewBag.Jugadores = lJugadores.Count();
            }
            if (responseTwo.IsSuccessStatusCode)
            {
                var lEquipos = await responseTwo.Content.ReadAsAsync<List<EquipoEntity>>();

                ViewBag.Equipos = lEquipos.Count();
            }

            #endregion

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
