using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.DAL.Contracts {
    public interface IRepositoryManager {

        IMeetEventRepository MeetEvent { get; }
        Task SaveAsynk();
    }
}
