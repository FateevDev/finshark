using FinShark.API.Dtos.User;
using Swashbuckle.AspNetCore.Filters;

namespace FinShark.API.Swagger.Examples;

public class UserLoginDtoExample : IExamplesProvider<UserLoginDto>
{
    public UserLoginDto GetExamples()
    {
        return new UserLoginDto("john_doe", "MySecurePassword123!");
    }
}

public class UserRegisterDtoExample : IExamplesProvider<UserRegisterDto>
{
    public UserRegisterDto GetExamples()
    {
        return new UserRegisterDto("john_doe", "john.doe@example.com", "MySecurePassword123!");
    }
}
