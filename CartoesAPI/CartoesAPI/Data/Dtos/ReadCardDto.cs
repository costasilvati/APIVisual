using System;
using System.ComponentModel.DataAnnotations;

namespace CartoesAPI.Data.Dtos
{
    public class ReadCardDto
    {
        [Required(ErrorMessage = "Card number is a required field")]
        [StringLength(16, ErrorMessage = "Field number can´t be largest 16 characers")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        public DateTime ExpirationDate { get; set; }
        public bool Blocked { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
    }
}
