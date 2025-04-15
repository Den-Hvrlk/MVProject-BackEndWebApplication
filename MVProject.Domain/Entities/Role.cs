using MVProject.Domain.Entities;
namespace MVProject.API.MVProject.Domain.Entities;

public partial class Role
{
    public int ID_Role { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> ID_User { get; set; } = new List<User>();
}
