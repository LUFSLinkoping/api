using System.ComponentModel.DataAnnotations;

namespace api.Database.Dtos
{
    public class MemberDto
    {
    }

    public class MemberRegisterDto
    {
        [Required]
        [StringLength(16)]
        [RegularExpression(@"^\d{6,8}[-|(\s)]{0,1}\d{4}$")]
        public string? PersonalNumber { get; set; }

        [Required]
        [StringLength(32)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(128)]
        [EmailAddress]
        public string? EmailAdress { get; set; }

        [Required]
        [StringLength(16)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(64)]
        public string? PostAdress { get; set; }

        [Required]
        [StringLength(7)]
        public string? ZipCode { get; set; }

        [Required]
        [StringLength(32)]
        public string? City { get; set; }
    }
}
