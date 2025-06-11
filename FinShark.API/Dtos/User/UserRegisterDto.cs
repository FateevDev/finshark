namespace FinShark.API.Dtos.User;

public record UserRegisterDto(
    string Username,
    string Email,
    string Password
);