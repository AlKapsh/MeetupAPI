namespace Meetup.WebApi.ViewModels {
    public class MeetTransferModel {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Manager { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public string Place { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}
