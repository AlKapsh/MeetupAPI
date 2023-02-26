using Meetup.DAL.Contracts;
using Meetup.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Repository {
    public class RepositoryManager : IRepositoryManager {
        private repContext _context;
        private IMeetEventRepository _eventRepository;

        public RepositoryManager(repContext repContext) {
            _context = repContext;
        }

        public IMeetEventRepository MeetEvent {
            get {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository(_context);
                return _eventRepository; 
            }
        }

        public async Task SaveAsynk() => await _context.SaveChangesAsync();
    }
}
