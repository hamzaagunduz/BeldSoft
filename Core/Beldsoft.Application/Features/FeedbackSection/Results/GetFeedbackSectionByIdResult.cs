namespace Beldsoft.Application.Features.FeedbackSection.Results
{
    public class GetFeedbackSectionByIdResult
    {
        public int? Id { get; set; }

        // Slider için büyük arka plan/resim
        public string? BigImageUrl { get; set; }

        // Kullanýcý resimleri
        public string? UserImageUrl1 { get; set; }
        public string? UserImageUrl2 { get; set; }
        public string? UserImageUrl3 { get; set; }

        // Kullanýcý isimleri
        public string? UserName1 { get; set; }
        public string? UserName2 { get; set; }
        public string? UserName3 { get; set; }

        // Kullanýcý unvanlarý / pozisyon
        public string? UserPosition1 { get; set; }
        public string? UserPosition2 { get; set; }
        public string? UserPosition3 { get; set; }

        // Yorum metinleri
        public string? Comment1 { get; set; }
        public string? Comment2 { get; set; }
        public string? Comment3 { get; set; }

        // Yýldýz sayýlarý
        public int? Rating1 { get; set; }
        public int? Rating2 { get; set; }
        public int? Rating3 { get; set; }
    }
}
