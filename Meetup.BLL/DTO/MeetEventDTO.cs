using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.DTO {
    public class MeetEventDTO {
        //public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Manager { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public string Place { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}
