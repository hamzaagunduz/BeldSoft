using AutoMapper;
using Beldsoft.Application.Features.GallerySection.Commands.UpdateGallerySection;
using Beldsoft.Application.Features.GallerySection.Queries.GetGallerySectionById;
using Beldsoft.Application.Features.GallerySection.Results;
using Beldsoft.MVC.ViewModels.GallerySection;

namespace Beldsoft.MVC.Mapping
{
    public class GallerySectionProfile : Profile
    {
        public GallerySectionProfile()
        {
            // Tekil mapler
            CreateMap<GetGallerySectionByIdResult, GallerySectionUpdateViewModel>().ReverseMap();
            CreateMap<GallerySectionUpdateViewModel, UpdateGallerySectionCommand>().ReverseMap();

            // GetAll için tekil map
            CreateMap<GetAllGallerySectionsResult, GallerySectionGetAllViewModel>().ReverseMap();
        }

    }
}
