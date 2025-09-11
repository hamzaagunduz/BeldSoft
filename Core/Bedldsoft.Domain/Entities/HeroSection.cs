using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedldsoft.Domain.Entities
{
    public class HeroSection
    {
        public int Id { get; set; }
        public string SubTitle { get; set; }       // fun happens!
        public string MainTitle { get; set; }      // The kids Centers
        public string MainTitleHighlight { get; set; } // Educatisson
        public string Description { get; set; }    // work and play come together ?
        public string SmallImageUrl { get; set; }   // hero-shape-1.svg
        public string BigImageUrl { get; set; }    // hero-star-icon.svg
    }
}
