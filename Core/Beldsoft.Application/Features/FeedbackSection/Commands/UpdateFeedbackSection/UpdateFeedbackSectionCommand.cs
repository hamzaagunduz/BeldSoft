using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.FeedbackSection.Commands.UpdateFeedbackSection
{
    public class UpdateFeedbackSectionCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        // Slider i�in b�y�k arka plan/resim
        public string? BigImageUrl { get; set; }

        // Kullan�c� resimleri
        public string? UserImageUrl1 { get; set; }
        public string? UserImageUrl2 { get; set; }
        public string? UserImageUrl3 { get; set; }

        // Kullan�c� isimleri
        public string? UserName1 { get; set; }
        public string? UserName2 { get; set; }
        public string? UserName3 { get; set; }

        // Kullan�c� unvanlar� / pozisyon
        public string? UserPosition1 { get; set; }
        public string? UserPosition2 { get; set; }
        public string? UserPosition3 { get; set; }

        // Yorum metinleri
        public string? Comment1 { get; set; }
        public string? Comment2 { get; set; }
        public string? Comment3 { get; set; }

        // Y�ld�z say�lar�
        public int? Rating1 { get; set; }
        public int? Rating2 { get; set; }
        public int? Rating3 { get; set; }
    }
}
