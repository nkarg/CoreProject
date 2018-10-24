using Data;
using DataRepository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.Concrete
{
    public class JugadorRepository : IJugadorRepository
    {
        private readonly DataFutsalContext _context;

        public JugadorRepository(DataFutsalContext context)
        {
            _context = context;
        }
        
        public Jugador GetByKey(int id)
        {
            return _context.Jugador.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public List<Jugador> GetAll()
        {
            return _context.Jugador.ToList();
        }

        public bool Add(Jugador jugador)
        {
            throw new NotImplementedException();
        }
        
        public bool Update(Jugador jugador)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Jugador jugador)
        {
            throw new NotImplementedException();
        }
    }
}
