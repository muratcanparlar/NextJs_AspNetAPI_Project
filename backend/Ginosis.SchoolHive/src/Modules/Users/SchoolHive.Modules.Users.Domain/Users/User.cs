namespace SchoolHive.Modules.Users.Domain.Users;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid IdentityId { get; set; }

    public static User Create(string email, string firstName, string lastName, Guid identityId)
    {
        return new User
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            CreatedDate = DateTime.UtcNow,
            IdentityId = identityId
        };
    }

}

