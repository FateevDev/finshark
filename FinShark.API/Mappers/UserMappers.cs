using FinShark.API.Dtos.User;
using FinShark.API.Models;

namespace FinShark.API.Mappers;

public static class UserMappers
{
    public static User ToUserFromRegisterDto(this UserRegisterDto dto)
    {
        return new User
        {
            UserName = dto.Username,
            Email = dto.Email,
        };
    }

    public static UserCreatedDto ToUserCreatedDto(this User user, string token)
    {
        return new UserCreatedDto(user.UserName!, user.Email!, token);
    }
}