using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Microsoft.Extensions.Options;
using System.Net;
using Api.TorMarket.Infrastructure.Options;
using Api.TorMarket.Domain.Models.External;
using Api.TorMarket.Application.Interfaces.Services;
using Auth0User = Auth0.ManagementApi.Models.User;
using UserrModel = Api.TorMarket.Domain.Models.External.UserModel;

namespace Api.TorMarket.Infrastructure.Services;

public class Auth0Service : IAuth0Service
{
    private const string ProviderName = "Auth0";
    private readonly IAuth0UsersClient _usersClient;
    private readonly Auth0Options _options;

    public Auth0Service
    (
        IAuth0UsersClient usersClient,
        IOptions<Auth0Options> options
    )
    {
        _usersClient = usersClient;
        _options = options.Value;
    }

    public virtual async Task<ApiResult<UserrModel>> UpdateUserAsync(
        string identityProviderId, 
        UpdateUserModel user
    )
    {
        Auth0User auth0User;
        try
        {
            auth0User = await _usersClient.UpdateAsync(identityProviderId, new UserUpdateRequest
            {
                Connection = _options.Connection,
                ClientId = _options.ClientId,
                Email = user.Email,
                EmailVerified = true,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = $"{user.FirstName} {user.LastName}",
                UserMetadata = new Auth0Metadata
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                }
            }).ConfigureAwait(false);
        }
        catch (ErrorApiException e)
        {
            return Failure<ApiResult<UserrModel>>(e);
        }

        return Success(auth0User);
    }

    public async Task<ApiResult<UserrModel>> GetUserAsync(string providerId)
    {
        Auth0User auth0User;
        try
        {
            auth0User = await _usersClient.GetAsync(providerId).ConfigureAwait(false);
        }
        catch (ErrorApiException e)
        {
            return Failure<ApiResult<UserrModel>>(e);
        }

        return Success(auth0User);
    }

    public async Task<ApiResult<IReadOnlyList<UserrModel>>> GetUserByEmail(string email)
    {
        IList<Auth0User> auth0UserList;
        try
        {
            auth0UserList = await _usersClient.GetUsersByEmailAsync(email.ToLowerInvariant())
                .ConfigureAwait(false);
        }
        catch (ErrorApiException e)
        {
            return Failure<ApiResult<IReadOnlyList<UserrModel>>>(e);
        }

        return Success(auth0UserList);
    }

    private static ApiResult<UserrModel> Success(Auth0User auth0User = null)
    {
        var userMetadata = auth0User?.UserMetadata;
        return new ApiResult<UserrModel>
        {
            Succeeded = true,
            StatusCode = HttpStatusCode.OK,
            Item = auth0User != null
                ? new UserrModel
                {
                    FirstName = userMetadata?.FirstName,
                    LastName = userMetadata?.LastName,
                    Email = auth0User.Email,
                    PhoneNumber = userMetadata?.PhoneNumber,
                    Provider = ProviderName,
                    ProviderSubjectId = auth0User.UserId,
                }
                : null
        };
    }

    private static ApiResult<IReadOnlyList<UserrModel>> Success(IEnumerable<Auth0User> auth0UserList)
    {
        return new ApiResult<IReadOnlyList<UserrModel>>
        {
            Succeeded = true,
            StatusCode = HttpStatusCode.OK,
            Item = auth0UserList.Select(u => new UserrModel
            {
                FirstName = u.UserMetadata?.FirstName,
                LastName = u.UserMetadata?.LastName,
                Email = u.Email,
                PhoneNumber = u.UserMetadata?.PhoneNumber,
                Provider = ProviderName,
                ProviderSubjectId = u.UserId
            }).ToList()
        };
    }

    private static T Failure<T>(ErrorApiException e) where T : ApiResult, new()
    {
        Enum.TryParse<HttpStatusCode>(e.StatusCode.ToString(), out var statusCode);
        return new T
        {
            Succeeded = false,
            StatusCode = statusCode,
            Message = e.ApiError.Message
        };
    }
}
