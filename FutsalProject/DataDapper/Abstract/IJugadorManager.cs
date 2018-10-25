using CoreDapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDapper.Abstract
{
    public interface IJugadorManager
    {
        /// <summary>
        /// Get all players
        /// </summary>
        /// <returns></returns>
        List<JugadorDapper> GetAll();

        /// <summary>
        /// Get one player by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        JugadorDapper GetById(int id);

        /// <summary>
        /// Add a new player
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        string Add(JugadorDapper jugador);

        /// <summary>
        /// Modify information of player
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        string Update(JugadorDapper jugador);


        /// <summary>
        /// Delete player
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        string Delete(int id);
    }
}
