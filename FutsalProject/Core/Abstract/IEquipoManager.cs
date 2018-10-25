using Core.Entities;
using Core.Infraestructure.Custom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
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
        ResultEntity Add(EquipoEntity jugador);

        /// <summary>
        /// Modify information of one specific team
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        ResultEntity Update(EquipoEntity jugador);


        /// <summary>
        /// Delete one specific team
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        ResultEntity Delete(int id);
    }
}
