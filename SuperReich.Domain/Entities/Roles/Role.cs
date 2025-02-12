using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.Roles
{
    public class Role: Audit
    {
        [Key]
        public int RoleId { get; private set; }
        public string Rolename { get; set; } = string.Empty;
    }
}
