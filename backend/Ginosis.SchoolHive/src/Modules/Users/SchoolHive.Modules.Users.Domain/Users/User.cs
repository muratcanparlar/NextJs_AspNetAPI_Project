namespace SchoolHive.Modules.Users.Domain.Users;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid UserProviderId { get; set; }

}

