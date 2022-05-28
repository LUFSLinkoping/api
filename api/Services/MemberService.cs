using api.Database;
using api.Database.Dtos;
using api.Database.Entities;

namespace api.Services
{
    public class MemberService
    {
        private readonly LufsDbContext _db;

        public MemberService(LufsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Register(MemberRegisterDto member)
        {
            var numSaved = 0;
            try
            {
                var transformedPN = member.PersonalNumber!.Replace("-", "");
                transformedPN = transformedPN.Length == 12 ? transformedPN[2..] : transformedPN;

                await _db.Members.AddAsync(new Member
                {
                    Token = Guid.NewGuid(),
                    PersonalNumber = transformedPN.Trim(),
                    FirstName = member.FirstName!.Trim(),
                    LastName = member.LastName!.Trim(),
                    EmailAdress = member.EmailAdress!.Trim(),
                    PhoneNumber = member.PhoneNumber!.Trim(),
                    PostAdress = member.PostAdress!.Trim(),
                    ZipCode = member.ZipCode!.Trim(),
                    City = member.City!.Trim()
                });
                numSaved = await _db.SaveChangesAsync();
            } 
            catch (Exception)
            {
                return false;
            }
            
            return numSaved > 0;
        }
    }
}
