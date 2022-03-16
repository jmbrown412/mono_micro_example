using APIModels;
using Data.Entities;

namespace OrchestrationService
{
    public interface IOrchestrator
    {
        Member AddMember(CreateMemberRequest req);
    }
}
