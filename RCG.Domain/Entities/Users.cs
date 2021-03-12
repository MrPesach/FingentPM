namespace RCG.Domain.Entities
{
    public class Users : DomainObject
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }
    }
}
