namespace APIModels
{
    public class CreateMemberRequest
    {
        public CreateMemberRequest(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
