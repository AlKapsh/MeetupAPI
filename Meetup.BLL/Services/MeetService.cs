using Meetup.BLL.Contracts;
using Meetup.BLL.DTO;
using Meetup.DAL.Repository;
using Meetup.DAL.Contracts;
using AutoMapper;
using Meetup.DAL.Models;

namespace Meetup.BLL.Services {
    public class MeetService : IMeetService {
        IRepositoryManager _repository;

        public MeetService(IRepositoryManager repo) {
            _repository = repo;
        }

        public void CreateMeet(MeetEventDTO eventDTO) {

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetEventDTO, MeetEvent>()).CreateMapper();
            var newEvent = mapper.Map<MeetEvent>(eventDTO);

            _repository.MeetEvent.CreateEvent(newEvent);
            _repository.SaveAsynk();
        }

        public IQueryable<MeetEventDTO> GetAllMeets() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetEvent, MeetEventDTO>()).CreateMapper();
            return mapper.Map<IQueryable<MeetEvent>, IQueryable<MeetEventDTO> >(_repository.MeetEvent.GetAllEvents(false));
        }

        public MeetEventDTO GetMeet(int id) {
            if(id == null)
                throw new ArgumentNullException("id");
            var meetEvent = _repository.MeetEvent.GetById(id, true);
            if (meetEvent == null)
                throw new ArgumentNullException("No such event");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetEvent, MeetEventDTO>()).CreateMapper();
            return mapper.Map<MeetEventDTO>(meetEvent);
        }
    }
}
