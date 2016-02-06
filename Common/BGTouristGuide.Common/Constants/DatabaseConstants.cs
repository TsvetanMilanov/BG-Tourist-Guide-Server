namespace BGTouristGuide.Common.Constants
{
    public class DatabaseConstants
    {
        public const string AdminUserRole = "Admin";
        public const string RegularUserRole = "Regular";

        public const int MinFirstNameLength = 1;
        public const int MaxFirstNameLength = 30;
        public const int MinLastNameLength = 1;
        public const int MaxLastNameLength = 30;

        public const int MaxParentTouristSiteDescriptionLength = 5000;
        public const int MinParentTouristSiteNameLength = 1;
        public const int MaxParentTouristSiteNameLength = 100;

        public const int MinTouristSiteNameLength = 1;
        public const int MaxTouristSiteNameLength = 100;

        public const int MinTouristSiteDescriptionLength = 5;
        public const int MaxTouristSiteDescriptionLength = 5000;

        public const int MinTouristSiteAddressLength = 5;
        public const int MaxTouristSiteAddressLength = 200;

        public const int MinRatingValue = 1;
        public const int MaxRatingValue = 10;

        public const int MinCommentContentLength = 5;
        public const int MaxCommentContentLength = 200;

        public const int MinQRImageNameLength = 5;
        public const int MaxQRImageNameLength = 200;

        public const int MinQRImageLinkLength = 10;
        public const int MaxQRImageLinkLength = 200;

        public const int MinTouristSitePointsValue = 0;
        public const int MaxGovernmentTouristSitePointsValue = 20;
        public const int MaxUserTouristSitePointsValue = 10;
    }
}
