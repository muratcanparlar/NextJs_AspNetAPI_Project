namespace SchoolHive.Modules.Users.Domain.Users;

public class User
{
    private readonly List<Role> _roles = [];
    private User()
    {
    }

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string IdentityId { get; set; }
    public IReadOnlyCollection<Role> Roles => _roles.ToList();

    public static User Create(string email, string firstName, string lastName, string identityId)
    {
        var user = new User
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            CreatedDate = DateTime.UtcNow,
            IdentityId = identityId
        };

        user._roles.Add(Role.Administrator);

        return user;
    }

}
