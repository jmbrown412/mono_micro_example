using Data;
using Data.Entities;

namespace MemberService
{
    public class MemberRepo : IMemberRepo
    {
        private readonly SampleDbContext _dbContext;

        public MemberRepo(SampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Member Add(Member member)
        {
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            return member;
        }
    }
}
