namespace Ginosis.SchoolHive.Rest.Contracts.Requests.Users;
public class UserRegister
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

