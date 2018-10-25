using CoreDapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDapper.Abstract
{
    public interface IEquipoManager
    {
        /// <summary>
        /// Get all teams
        /// </summary>
        /// <returns></returns>
        List<EquipoEntity> GetAll();

        /// <summary>
        /// Get one team by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EquipoEntity GetById(int id);

        /// <summary>
        /// Add a new team
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        string Add(EquipoEntity jugador);

        /// <summary>
        /// Modify information of one specific team
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        string Update(EquipoEntity jugador);

        /// <summary>
        /// Delete one specific team
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        string Delete(int id);
    }
}
