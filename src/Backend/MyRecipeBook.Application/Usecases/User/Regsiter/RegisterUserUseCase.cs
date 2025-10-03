using MyRecipeBook.Application.Usecases.User.Register;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Communication.Usecases.User.Regsiter;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        // Validar a requisição;
        Validate(request);
        
        // mapear a request em uma entidade;
        // criptografar a senha;
        // salvar a entidadde no banco de dados;
        return new ResponseRegisteredUserJson
        {
            Name = request.Name
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage);

            throw new ErrorOnValdiationException(errorMessages.ToList());
        }
    }
}