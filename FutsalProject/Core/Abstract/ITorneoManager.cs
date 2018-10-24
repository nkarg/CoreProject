using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface ITorneoManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TorneoEntity> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TorneoEntity GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Torneo"></param>
        /// <returns></returns>
        bool Add(TorneoEntity torneo);
    }
}
