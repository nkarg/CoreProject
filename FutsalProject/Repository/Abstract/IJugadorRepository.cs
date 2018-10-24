using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Abstract
{
    public interface IJugadorRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Jugador GetByKey(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Jugador> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        bool Add(Jugador jugador);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        bool Update(Jugador jugador);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        bool Delete(Jugador jugador);
    }
}
