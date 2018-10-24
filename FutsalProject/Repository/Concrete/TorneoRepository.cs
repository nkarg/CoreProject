using Data;
using DataRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.Concrete
{
    public class TorneoRepository : ITorneoRepository
    {
        private readonly DataFutsalContext _context;

        public TorneoRepository(DataFutsalContext context)
        {
            _context = context;
        }

        public Torneo GetByKey(int id)
        {
            return _context.Torneo.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public List<Torneo> GetAll()
        {
            return _context.Torneo.ToList();
        }

        public bool Add(Torneo torneo)
        {
            var result = true;
            try
            {
                var test = _context.Torneo.Add(torneo);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Update(Torneo torneo)
        {
            var result = true;
            try
            {
                _context.Torneo.Update(torneo);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool Delete(Torneo torneo)
        {
            var result = true;
            try
            {
                _context.Torneo.Remove(torneo);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
