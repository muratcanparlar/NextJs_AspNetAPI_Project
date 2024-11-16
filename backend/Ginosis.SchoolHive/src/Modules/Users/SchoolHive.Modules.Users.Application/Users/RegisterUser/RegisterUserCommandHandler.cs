
using Ginosis.Common.Application;
using Ginosis.Common.Application.Data;
using Ginosis.Common.Application.Messaging;
using SchoolHive.Modules.Users.Domain.Users;

namespace SchoolHive.Modules.Users.Application.Users.RegisterUser;
public class RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        //await Task.CompletedTask;

        //if (request.LastName.StartsWith("Par"))
        //{
        //    return Result.Failure<Guid>(UserErrors.NotFound(Guid.NewGuid()));
        //}
        //if (request.LastName.StartsWith("Car2"))
        //{
        //    return Result.Failure<Guid>(UserErrors.AlreadyUpdated);
        //}
        //int a = 0;
        //var k = 5 / a;

        //var id = Guid.NewGuid();
        //return id;
        try
        {
            var user = User.Create(request.Email, request.FirstName, request.LastName, Guid.NewGuid());

            userRepository.Insert(user);

            await unitOfWork.SaveChangesAsync();

            return user.Id;
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
}

