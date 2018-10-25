using Data;
using DataRepository.Abstract;
using DataRepository.Infraestructure.Custom;
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

        public RepositoryResult Add(Torneo torneo)
        {
            var result = new RepositoryResult(true);
            try
            {
                var test = _context.Torneo.Add(torneo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.ActionResult = false;
                result.Error = ex;
            }

            return result;
        }

        public RepositoryResult Update(Torneo torneo)
        {
            var result = new RepositoryResult(true);
            try
            {
                _context.Torneo.Update(torneo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.ActionResult = false;
                result.Error = ex;
            }

            return result;
        }

        public RepositoryResult Delete(Torneo torneo)
        {
            var result = new RepositoryResult(true);
            try
            {
                _context.Torneo.Remove(torneo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.ActionResult = false;
                result.Error = ex;
            }

            return result;
        }
    }
}
