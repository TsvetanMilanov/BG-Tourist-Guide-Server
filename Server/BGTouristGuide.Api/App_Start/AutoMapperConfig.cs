namespace BGTouristGuide.Api.App_Start
{
    using System.Linq;

    using AutoMapper;

    using BGTouristGuide.Models;
    using Models.ResponseModels.Common;
    using Models.ResponseModels.TouristSites;
    using Models.ResponseModels.Users;

    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfig;

        public static void Initialize()
        {
            MapperConfig = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<ParentTouristSite, FullTouristSiteResponseModel>()
                    .ForMember(
                        m => m.Type,
                        opts => opts.MapFrom(p => (int)p.Type)); ;

                mapper.CreateMap<TouristSite, TouristSiteResponseModel>()
                    .ForMember(
                        m => m.Rating,
                        opts => opts.MapFrom(t => t.Ratings.Count > 0 ? t.Ratings.Sum(r => r.Value) / t.Ratings.Count : 0))
                    .ForMember(
                        m => m.Status,
                        opts => opts.MapFrom(t => (int)t.Status));

                mapper.CreateMap<TouristSite, SimpleTouristSiteResponseModel>();

                mapper.CreateMap<ParentTouristSite, SimpleParentTouristSiteResponseModel>();

                mapper.CreateMap<User, ScoreboardResponseModel>().ForMember(
                        m => m.Rating,
                        opts => opts.MapFrom(u => u.Ratings.Sum(r => r.Value)));

                mapper.CreateMap<User, FullUserResponseModel>();

                mapper.CreateMap<Badge, BadgeResponseModel>();
            });

            MapperConfig.AssertConfigurationIsValid();
        }
    }
}