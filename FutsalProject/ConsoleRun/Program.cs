using CoreDapper.Concrete;
using CoreDapper.Entities;
using System;

namespace ConsoleRun
{
    class Program
    {
        static void Main(string[] args)
        {
            var equipoManager = new EquipoManager();
            var jugadorManager = new JugadorManager();
            
            Console.WriteLine("Bienvenido a la prueba de Dapper!");
            Console.WriteLine("*********************************" + Environment.NewLine);
            Console.WriteLine("Añadiendo un EQUIPO");
            Console.WriteLine("Datos:");

            var equipo = new EquipoDapper
            {
                NombreLargo = "Submarino Footballl Club",
                NombreCorto = "Submarino",
                FechaAfiliacion = DateTime.Today.ToShortDateString()
            };

            Console.WriteLine("NombreLargo: " + equipo.NombreLargo);
            Console.WriteLine("NombreCorto: " + equipo.NombreCorto);
            Console.WriteLine("FechaAfiliacion: " + equipo.FechaAfiliacion + Environment.NewLine);
            Console.WriteLine("Presiona una tecla para continuar" + Environment.NewLine);
            Console.ReadKey();

            Console.WriteLine("Resultado del insert: " + equipoManager.Add(equipo));
            var submarino = equipoManager.GetAll().Find(x => x.NombreCorto.Equals("Submarino"));
            Console.WriteLine("ID del ultimo registro: " + submarino.Id);
            Console.Write("Escribe un nuevo nombre corto para Submarino: ");

            submarino.NombreCorto = Console.ReadLine();

            Console.WriteLine(Environment.NewLine + "Modificando datos de Equipo");
            Console.WriteLine("Resultado del update: " + equipoManager.Update(submarino) + Environment.NewLine);

            submarino = equipoManager.GetById(submarino.Id);

            Console.WriteLine("NombreLargo: " + submarino.NombreLargo);
            Console.WriteLine("NombreCorto: " + submarino.NombreCorto);
            Console.WriteLine("FechaAfiliacion: " + submarino.FechaAfiliacion + Environment.NewLine);
            Console.WriteLine("Presiona una tecla para continuar" + Environment.NewLine);
            Console.ReadKey();

            Console.WriteLine("Eliminando Equipo");
            Console.WriteLine("Resultado del delete: " + equipoManager.Delete(submarino.Id) + Environment.NewLine);
            Console.WriteLine("Presiona una tecla para continuar" + Environment.NewLine);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Añadiendo un Jugador");
            Console.WriteLine("Datos:");

            var jugador = new JugadorDapper
            {
                Dni = 34973249,
                Nombres = "Eduardo Alejandro",
                Apellidos = "Rojo Cadenas",
                FechaNacimiento = "23/01/1990",
                Direccion = "Necochea 3148",
                Telefono = "3794801803",
                TelefonoEmergencia = "4434013",
                IdPieHabil = 1,
                FechaAfiliacion = DateTime.Today.ToShortDateString()
            };

            Console.WriteLine("Nombres: " + jugador.Nombres);
            Console.WriteLine("Apellidos: " + jugador.Apellidos);
            Console.WriteLine("FechaNacimiento: " + jugador.FechaNacimiento);
            Console.WriteLine("Dni: " + jugador.Dni);
            Console.WriteLine("Direccion: " + jugador.Direccion);
            Console.WriteLine("Telefono: " + jugador.Telefono);
            Console.WriteLine("TelefonoEmergencia: " + jugador.TelefonoEmergencia);
            Console.WriteLine("PieHabil: " + jugador.IdPieHabil);
            Console.WriteLine("FechaAfiliacion: " + jugador.FechaAfiliacion + Environment.NewLine);
            Console.WriteLine("Presiona una tecla para continuar" + Environment.NewLine);
            Console.ReadKey();

            Console.WriteLine("Resultado del insert: " + jugadorManager.Add(jugador));
            var player = jugadorManager.GetAll().Find(x => x.Dni.Equals(34973249));
            Console.WriteLine("ID del ultimo registro: " + player.Id);
            Console.Write("Escribe un nuevo telefono para el jugador: ");

            player.Telefono = Console.ReadLine();

            Console.WriteLine(Environment.NewLine + "Modificando datos de Jugador");
            Console.WriteLine("Resultado del update: " + jugadorManager.Update(player) + Environment.NewLine);

            player = jugadorManager.GetById(player.Id);

            Console.WriteLine("Nombres: " + player.Nombres);
            Console.WriteLine("Apellidos: " + player.Apellidos);
            Console.WriteLine("Dni: " + player.Dni);
            Console.WriteLine("Direccion: " + player.Direccion);
            Console.WriteLine("Telefono: " + player.Telefono);
            Console.WriteLine("Presiona una tecla para continuar" + Environment.NewLine);
            Console.ReadKey();

            Console.WriteLine("Eliminando Jugador");
            Console.WriteLine("Resultado del delete: " + jugadorManager.Delete(player.Id) + Environment.NewLine);
            Console.WriteLine("Presiona una tecla para continuar" + Environment.NewLine);
            Console.ReadKey();
        }
    }
}
