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

        public void DeleteMeet(int id) {

            var entityToDelete = _repository.MeetEvent.GetById(id, trackChanges: true);
            _repository.MeetEvent.DeleteEvent(entityToDelete);
            _repository.SaveAsynk();
        }

        public IQueryable<MeetEventDTO> GetAllMeets() {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetEvent, MeetEventDTO>().ReverseMap()).CreateMapper();
            var ents = _repository.MeetEvent.GetAllEvents(false);
            var a = mapper.Map<List<MeetEventDTO>>(ents); // Do smth list != IQueryable 
            return a.AsQueryable();
        }

        public MeetEventDTO GetMeet(int id) {
            if(id == null)
                throw new ArgumentNullException("id");
            var meetEvent = _repository.MeetEvent.GetById(id, false);
            if (meetEvent == null)
                throw new ArgumentNullException("No such event");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetEvent, MeetEventDTO>()).CreateMapper();
            return mapper.Map<MeetEventDTO>(meetEvent);
        }

        public void UpdateMeet(int id, MeetEventDTO meetEventDTO) {
            var entityToUpdate = _repository.MeetEvent.GetById(id, trackChanges: true);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetEventDTO, MeetEvent>()).CreateMapper();
            entityToUpdate = mapper.Map(meetEventDTO, entityToUpdate);

            _repository.SaveAsynk();
        }
    }
}
