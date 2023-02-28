using Meetup.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Contracts {
    public interface IMeetService {
        IQueryable<MeetEventDTO> GetAllMeets();
        MeetEventDTO GetMeet(int id);
        void CreateMeet(MeetEventDTO eventDTO);
        void DeleteMeet(int id);
        void UpdateMeet(int id, MeetEventDTO meetEventDTO);
    }
}
