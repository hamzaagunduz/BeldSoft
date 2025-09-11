using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedldsoft.Domain.Entities
{
    public class SessionSection
    {
        public int Id { get; set; }

        // Genel başlıklar
        public string SubTitle { get; set; }   // "Session Times"
        public string MainTitle { get; set; }  // "Your kids Are 100% Safe at Our Care."

        // Session 1
        public string Title1 { get; set; }      // "Brain Train"
        public string Time1 { get; set; }       // "8.00am - 10.00am"
        public string IconUrl1 { get; set; }    // "~/toddly/assets//img/icons/session-icon-h1-1-1.svg"

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
