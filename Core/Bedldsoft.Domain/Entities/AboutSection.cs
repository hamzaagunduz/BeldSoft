using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedldsoft.Domain.Entities
{
    public class AboutSection
    {
        public int? Id { get; set; }

        // Görseller
        public string? BigImageUrl { get; set; }      // vs-about-h1-2.jpg
        public string? SmallImageUrl { get; set; }    // vs-about-h1-1.jpg

        // Genel Başlık
        public string? SubTitle { get; set; }         // "School Facilities"
        public string? MainTitle { get; set; }        // "Learning Opportunity For Kids"

        // Deneyim kısmı
        public string? ExperienceNumber { get; set; } // "21+"
        public string? ExperienceText { get; set; }   // "years of experience"

        // Tab 1 (Our History)
        public string? Title1 { get; set; }              // "our history"
        public string? Title1Description { get; set; }   // paragraf metni
        public string? Title1Step1 { get; set; }         // "Learning Opportunity For Kids"
        public string? Title1Step2 { get; set; }         // "Your Child Will Take"


        // Tab 2 (School)
        public string? Title2 { get; set; }
        public string? Title2Description { get; set; }
        public string? Title2Step1 { get; set; }
        public string? Title2Step2 { get; set; }


        // Tab 3 (Kids)
        public string ?Title3 { get; set; }
        public string? Title3Description { get; set; }
        public string ?Title3Step1 { get; set; }
        public string ?Title3Step2 { get; set; }

    }

}
