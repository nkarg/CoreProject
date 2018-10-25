using Data;
using DataRepository.Infraestructure.Custom;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Abstract
{
    public interface IEquipoRepository
    {
        /// <summary>
        /// Obtiene un equipo mediante un ID específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Equipo GetByKey(int id);

        /// <summary>
        /// Obtiene todos los equipos
        /// </summary>
        /// <returns></returns>
        List<Equipo> GetAll();

        /// <summary>
        /// Añade un nuevo equipo
        /// </summary>
        /// <param name="equipo"></param>
        /// <returns></returns>
        RepositoryResult Add(Equipo equipo);

        /// <summary>
        /// Actualiza un equipo específico
        /// </summary>
        /// <param name="equipo"></param>
        /// <returns></returns>
        RepositoryResult Update(Equipo equipo);

        /// <summary>
        /// Borra un equipo específico
        /// </summary>
        /// <param name="equipo"></param>
        /// <returns></returns>
        RepositoryResult Delete(Equipo equipo);
    }
}
