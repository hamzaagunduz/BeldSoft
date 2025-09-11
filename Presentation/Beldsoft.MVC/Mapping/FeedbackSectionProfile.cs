using AutoMapper;
using Beldsoft.Application.Features.FeedbackSection.Commands.UpdateFeedbackSection;
using Beldsoft.Application.Features.FeedbackSection.Queries.GetFeedbackSectionById;
using Beldsoft.Application.Features.FeedbackSection.Queries.GetAllFeedbackSections;
using Beldsoft.MVC.ViewModels.FeedbackSection;
using Beldsoft.Application.Features.FeedbackSection.Results;

namespace Beldsoft.MVC.Mapping
{
    public class FeedbackSectionProfile : Profile
    {
        public FeedbackSectionProfile()
        {
            CreateMap<GetAllFeedbackSectionsResult, FeedbackSectionGetAllViewModel>().ReverseMap();
            CreateMap<GetFeedbackSectionByIdResult, FeedbackSectionUpdateViewModel>().ReverseMap();
            CreateMap<FeedbackSectionUpdateViewModel, UpdateFeedbackSectionCommand>().ReverseMap();
        }
    }
}
