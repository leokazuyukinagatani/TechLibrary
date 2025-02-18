using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Application.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        throw new NotImplementedException();
    }
}
