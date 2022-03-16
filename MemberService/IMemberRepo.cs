using Data.Entities;

namespace MemberService
{
    public interface IMemberRepo
    {
        Member Add(Member member);
    }
}
