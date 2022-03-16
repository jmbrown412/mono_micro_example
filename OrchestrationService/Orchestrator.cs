
using APIModels;
using Data.Entities;
using KYCService;
using MemberService;

namespace OrchestrationService
{
    public class Orchestrator : IOrchestrator
    {
        // All micro services can be consumed by this one orchestration layer
        private readonly IMemberService _memberService;
        private readonly IKYCService _kycService;

        public Orchestrator(IMemberService memberService, IKYCService kycService)
        {
            _memberService = memberService;
            _kycService = kycService;
        }

        public Member AddMember(CreateMemberRequest req)
        {
            try
            {
                var passedKyc = _kycService.CheckUser(req.Name);
                return _memberService.Add(new Member(req.Name));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
