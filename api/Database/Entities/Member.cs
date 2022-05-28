using api.Util;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace api.Database.Entities
{
    [Index(nameof(PersonalNumber), IsUnique = true), Index(nameof(Token), IsUnique = true)]
    public class Member
    {
        [Key]
        public long Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Token { get; set; }

        /* Personal Information */
        [MaxLength(16)]
        public string? PersonalNumber { get; set; }
        [MaxLength(32)]
        public string? FirstName { get; set; }
        [MaxLength(64)]
        public string? LastName { get; set; }

        /* Contact Information */
        [MaxLength(128)]
        public string? EmailAdress { get; set; }
        [MaxLength(16)]
        public string? PhoneNumber { get; set; }
        [MaxLength(64)]
        public string? PostAdress { get; set; }
        [MaxLength(7)]
        public string? ZipCode { get; set; }
        [MaxLength(32)]
        public string? City { get; set; }

        /* Meta */
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;

        /* Relationships */
        public IEnumerable<MemberRegistration>? MemberRegistrations { get; set; }

        /* Calculated properties */

        [NotMapped]
        public string? FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
