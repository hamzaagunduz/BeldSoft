namespace Beldsoft.Application.Features.HeroSection.Results
{
    public class GetAllHeroSectionsResult
    {
        public int Id { get; set; }

        public string SubTitle { get; set; }            // fun happens!
        public string MainTitle { get; set; }           // The kids Centers
        public string MainTitleHighlight { get; set; }  // Educatisson
        public string Description { get; set; }         // work and play come together ?

    }
}
