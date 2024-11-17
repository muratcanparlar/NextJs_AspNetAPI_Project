
using Ginosis.Common.Application;
using Ginosis.Common.Application.Data;
using Ginosis.Common.Application.Messaging;
using SchoolHive.Modules.Users.Application.Abstractions.Identity;
using SchoolHive.Modules.Users.Domain.Users;

namespace SchoolHive.Modules.Users.Application.Users.RegisterUser;
public class RegisterUserCommandHandler(IIdentityProviderService identityProviderService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        Result<string> result = await identityProviderService.RegisterUserAsync(
            new UserModel(request.Email, request.Password, request.FirstName, request.LastName)
            , cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }

        var user = User.Create(request.Email, request.FirstName, request.LastName, result.Value);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync();

        return user.Id;

    }
}

