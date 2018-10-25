using Data;
using DataRepository.Infraestructure.Custom;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Abstract
{
    public interface ITorneoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Torneo GetByKey(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Torneo> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="torneo"></param>
        /// <returns></returns>
        RepositoryResult Add(Torneo torneo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="torneo"></param>
        /// <returns></returns>
        RepositoryResult Update(Torneo torneo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="torneo"></param>
        /// <returns></returns>
        RepositoryResult Delete(Torneo torneo);
    }
}
