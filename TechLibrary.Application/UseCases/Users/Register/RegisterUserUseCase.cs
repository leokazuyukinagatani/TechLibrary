using FluentValidation.Results;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception.ExceptionsBase;
using TechLibrary.Exception;

namespace TechLibrary.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await ValidateAsync(request);

        throw new NotImplementedException();
    }

    private async Task ValidateAsync(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        //var emailExist = await _usersReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        var emailExist = false;

        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
