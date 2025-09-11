namespace Beldsoft.Application.Features.SessionSection.Results
{
    public class GetSessionSectionByIdResult
    {
        public int Id { get; set; }

        // Genel baþlýklar
        public string SubTitle { get; set; }
        public string MainTitle { get; set; }

        // Session 1
        public string Title1 { get; set; }
        public string Time1 { get; set; }
        public string IconUrl1 { get; set; }

        // Session 2
        public string Title2 { get; set; }
        public string Time2 { get; set; }
        public string IconUrl2 { get; set; }

        // Session 3
        public string Title3 { get; set; }
        public string Time3 { get; set; }
        public string IconUrl3 { get; set; }

        // Session 4
        public string Title4 { get; set; }
        public string Time4 { get; set; }
        public string IconUrl4 { get; set; }
    }
}
