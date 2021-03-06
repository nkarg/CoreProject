﻿using Data;
using DataRepository.Infraestructure.Custom;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Abstract
{
    public interface IJugadorRepository
    {
        /// <summary>
        /// Obtiene un jugador mediante un ID específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Jugador GetByKey(int id);

        /// <summary>
        /// Obtiene todos los jugadores
        /// </summary>
        /// <returns></returns>
        List<Jugador> GetAll();

        /// <summary>
        /// Añade un nuevo jugador
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        RepositoryResult Add(Jugador jugador);

        /// <summary>
        /// Actualiza un jugador específico
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        RepositoryResult Update(Jugador jugador);

        /// <summary>
        /// Borra un jugador específico
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        RepositoryResult Delete(Jugador jugador);
    }
}
