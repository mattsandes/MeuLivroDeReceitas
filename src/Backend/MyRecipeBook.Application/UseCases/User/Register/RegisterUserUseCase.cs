using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        // validar a request;
        
        // mapear a request em uma entidade;
        
        //criptografar a senha do usuario;
        
        // salvar no banco de dados;
        
        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }
}