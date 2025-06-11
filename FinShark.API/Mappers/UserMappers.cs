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
}