namespace BGTouristGuide.Common.Constants
{
    public class GlobalConstants
    {
        // TODO: Add production application url.
#if (DEBUG)
        public const string ApplicationUrl = "http://localhost:25906";
#else
        public const string ApplicationUrl = "production url";
#endif
    }
}
