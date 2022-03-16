using Data.Entities;

namespace MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepo _memberRepo;

        public MemberService(IMemberRepo memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public Member Add(Member member)
        {
            try
            {
                return _memberRepo.Add(member);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
