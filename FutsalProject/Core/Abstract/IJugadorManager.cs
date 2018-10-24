using Core.Entities;
using Core.Infraestructure.Custom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IJugadorManager
    {
        /// <summary>
        /// Get all players
        /// </summary>
        /// <returns></returns>
        List<JugadorEntity> GetAll();

        /// <summary>
        /// Get one player by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        JugadorEntity GetById(int id);

        /// <summary>
        /// Add a new player
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        ResultEntity Add(JugadorEntity jugador);

        /// <summary>
        /// Modify information of player
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        ResultEntity Update(JugadorEntity jugador);


        /// <summary>
        /// Delete player
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        ResultEntity Delete(int id);
    }
}
