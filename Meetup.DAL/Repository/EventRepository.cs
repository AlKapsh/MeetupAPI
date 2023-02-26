using Meetup.DAL.Contracts;
using Meetup.DAL.EF;
using Meetup.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Repository {
    public class EventRepository : RepositoryBase<MeetEvent> ,IMeetEventRepository {
        public EventRepository(repContext context) : base(context) {}

        public MeetEvent GetById(int id, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefault();
        public IQueryable<MeetEvent> GetAllEvents(bool trackChanges) =>
            FindAll(trackChanges);
        public void CreateEvent(MeetEvent meet) => Create(meet);

        public void DeleteEvent(MeetEvent meet) => Delete(meet);

        public void UpdateEvent(MeetEvent meet) => Update(meet);
    }
}
