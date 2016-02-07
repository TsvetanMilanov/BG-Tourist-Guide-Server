namespace BGTouristGuide.Services.Contracts
{
    using System.Collections.Generic;

    public interface IQrCodeServices
    {
        void GenerateQrCodesForIds(string directory, IEnumerable<string> items);
    }
}
