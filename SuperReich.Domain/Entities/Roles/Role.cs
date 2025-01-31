using SuperReich.Domain.Entities.Users;

namespace SuperReich.Domain.Entities.Roles
{
    public class Role
    {
        public int Id { get; private set; }
        public string Rolename { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
