using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Blogs.Results.BlogResults
{
    public class GetBlogAllResult
    {
        public int BlogId { get; set; }           // Blog'un benzersiz ID'si
        public string Title { get; set; }         // Başlık
        public string Content { get; set; }       // İçerik
        public DateTime CreatedAt { get; set; }   // Oluşturulma tarihi
        public DateTime? UpdatedAt { get; set; }  // Güncellenme tarihi (opsiyonel)
    }
}
