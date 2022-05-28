using api.Database.Dtos;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class MemberController : BaseController
    {
        private readonly ILogger<MemberController> _logger;
        private readonly MemberService _memberService;

        public MemberController(ILogger<MemberController> logger, MemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<bool> Register(MemberRegisterDto member)
        {
            if (!ModelState.IsValid)
                return false;
            return await _memberService.Register(member);
        }


    }
}
