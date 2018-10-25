using Data;
using DataRepository.Abstract;
using DataRepository.Infraestructure.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.Concrete
{
    public class EquipoRepository: IEquipoRepository
    {
        private readonly DataFutsalContext _context;

        public EquipoRepository(DataFutsalContext context)
        {
            _context = context;
        }

        public Equipo GetByKey(int id)
        {
            return _context.Equipo.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public List<Equipo> GetAll()
        {
            return _context.Equipo.ToList();
        }

        public RepositoryResult Add(Equipo equipo)
        {
            var result = new RepositoryResult(true);
            try
            {
                var test = _context.Equipo.Add(equipo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.ActionResult = false;
                result.Error = ex;
            }

            return result;
        }

        public RepositoryResult Update(Equipo equipo)
        {
            var result = new RepositoryResult(true);
            try
            {
                _context.Equipo.Update(equipo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.ActionResult = false;
                result.Error = ex;
            }

            return result;
        }

        public RepositoryResult Delete(Equipo equipo)
        {
            var result = new RepositoryResult(true);
            try
            {
                _context.Equipo.Remove(equipo);
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
