using Meetup.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Contracts {
    internal interface IEventRepository {
        MeetEvent GetById(int id, bool trackChanges);

        IQueryable<MeetEvent> GetAllEvents(bool trackChanges);

        void CreateEvent();

        void UpdateEvent();

        void DeleteEvent();

    }
}
