using Ginosis.Common.Application;
using SchoolHive.Modules.Users.Application.Abstractions.Identity;

namespace SchoolHive.Modules.Users.Infrastructure.Identity;

internal class IdentityProviderService(KeyCloakClient keyCloakClient) : IIdentityProviderService
{
    private const string PasswordCredentialType = "Password";
    //POST /admin/realms/{realm}/users
    public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken)
    {
        var userRepresentation = new UserRepresentation(
            user.Email,
            user.Email,
            user.FirstName,
            user.LastName,
            true,
            true,
            [new CredentialRepresentation(PasswordCredentialType, user.Password, false)]);

        try
        {
            string identityId = await keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);
            return identityId;
        }
        catch (HttpRequestException exception) when (exception.StatusCode == System.Net.HttpStatusCode.Conflict)
        {

            //todo: add log error
            return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnique);
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
}

