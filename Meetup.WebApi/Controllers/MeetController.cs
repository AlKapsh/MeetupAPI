using AutoMapper;
using Azure.Core.Pipeline;
using Meetup.BLL.Contracts;
using Meetup.BLL.DTO;
using Meetup.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Meetup.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : Controller {
        IMeetService _meetService;

        public MeetController(IMeetService mserv) {
            _meetService = mserv;
        }
        internal IActionResult Index() {
            return RedirectToActionPermanent("AllMeets");
        }


        [HttpGet(Name = "AllMeets")]
        public IActionResult GetMeets() {
            var meets = _meetService.GetAllMeets();
            return Ok(meets);
        }

        [HttpGet ("{id}", Name = "MeetById")]
        public IActionResult GetMeetById([FromBody] int id) {
            var meet = _meetService.GetMeet(id);
            return Ok(meet);
        }

        [HttpPost(Name = "SetMeet")]
        public IActionResult PostMeet([FromBody] MeetTransferModel model) {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MeetTransferModel, MeetEventDTO>()).CreateMapper();
            var entityToSet = mapper.Map<MeetEventDTO>(model);
            _meetService.CreateMeet(entityToSet);
            return CreatedAtRoute("SetMeet", entityToSet);
        }
    }
}
