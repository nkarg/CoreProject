using Data;
using DataRepository.Infraestructure.Custom;
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
        RepositoryResult Add(Jugador jugador);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        RepositoryResult Update(Jugador jugador);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        RepositoryResult Delete(Jugador jugador);
    }
}
