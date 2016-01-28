namespace BGTouristGuide.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Constants;
    public class Comment
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [MinLength(DatabaseConstants.MinCommentContentLength)]
        [MaxLength(DatabaseConstants.MaxCommentContentLength)]
        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User Author { get; set; }
    }
}