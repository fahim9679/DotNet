using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Repositories.Implementations
{
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;

        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
        }

        public IEnumerable<State> GetAll()
        {
            var States=_context.States.ToList();
            return States;
        }

        public State GetById(int id)
        {
            var State = _context.States.SingleOrDefault(x => x.Id == id);
            return State;
        }

        public void RemoveData(State state)
        {
            _context.States.Remove(state);
            _context.SaveChanges();
        }

        public void Save(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
        }
    }
}
