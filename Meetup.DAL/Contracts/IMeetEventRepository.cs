using Meetup.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Contracts {
    public interface IMeetEventRepository {
        MeetEvent GetById(int id, bool trackChanges);

        IQueryable<MeetEvent> GetAllEvents(bool trackChanges);

        void CreateEvent(MeetEvent meet);

        void UpdateEvent(MeetEvent meet);

        void DeleteEvent(MeetEvent meet);

    }
}
