using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Database.Entities
{
    [Index(nameof(Year), nameof(MemberId), IsUnique = true)]
    public class MemberRegistration
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public long MemberId { get; set; }
        public Member? Member { get; set; }

        public MemberRegistrationType RegistrationType { get; set; }
        public MemberRegistrationSDGF SDGF { get; set; }
        public MemberRegistrationPDGA PDGA { get; set; }

        public MemberRegistrationStatus Status { get; set; }
    }

    public enum MemberRegistrationType
    {
        FullMember = 10
    }

    public enum MemberRegistrationSDGF
    {
        No = 0,
        Yes = 10
    }

    public enum MemberRegistrationPDGA
    {
        None = 0,
        Am = 10,
        Pro = 20
    }

    public enum MemberRegistrationStatus 
    { 
        Registered = 10,
        Billed = 50,
        Complete = 100,
        Denied = 400
    }
}
