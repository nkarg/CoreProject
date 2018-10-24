using Data;
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
        bool Add(Torneo torneo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="torneo"></param>
        /// <returns></returns>
        bool Update(Torneo torneo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="torneo"></param>
        /// <returns></returns>
        bool Delete(Torneo torneo);
    }
}
