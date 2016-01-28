namespace BGTouristGuide.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class QRImage
    {
        public int Id { get; set; }

        [MinLength(DatabaseConstants.MinQRImageNameLength)]
        [MaxLength(DatabaseConstants.MaxQRImageNameLength)]
        [Required]
        public string Name { get; set; }

        public byte[] Content { get; set; }

        [MinLength(DatabaseConstants.MinQRImageLinkLength)]
        [MaxLength(DatabaseConstants.MaxQRImageLinkLength)]
        [Required]
        public string Link { get; set; }
    }
}
