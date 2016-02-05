namespace BGTouristGuide.Common.Constants
{
    public class GlobalConstants
    {
        public const string ServicesAssemblyName = "BGTouristGuide.Services";

        public const int PageSize = 20;

        // TODO: Add production application url.
#if (DEBUG)
        public const string ApplicationUrl = "http://localhost:25906";
#else
        public const string ApplicationUrl = "http://bg-tourist-guide-server.apphb.com";
#endif
    }
}
