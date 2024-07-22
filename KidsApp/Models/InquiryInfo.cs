using System;
using System.ComponentModel.DataAnnotations;

namespace KidsApp.Models
{
    public class InquiryInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime InquiryDate { get; set; }
    }
}
