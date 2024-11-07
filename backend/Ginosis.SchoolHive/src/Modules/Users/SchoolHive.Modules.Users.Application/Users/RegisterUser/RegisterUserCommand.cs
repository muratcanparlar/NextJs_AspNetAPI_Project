using Ginosis.Common.Application.Messaging;


namespace SchoolHive.Modules.Users.Application.Users.RegisterUser;
public record RegisterUserCommand(string FirstName, string LastName, string Email,string Password):ICommand<Guid>;
