using FinShark.API.Models;

namespace FinShark.API.Services;

public interface ITokenService
{
    public string CreateToken(User user);
}