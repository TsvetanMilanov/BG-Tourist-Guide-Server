namespace BGTouristGuide.Api.App_Start
{
    using System.Linq;

    using AutoMapper;

    using BGTouristGuide.Models;
    using Models.ResponseModels.TouristSites;

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
            });

            MapperConfig.AssertConfigurationIsValid();
        }
    }
}