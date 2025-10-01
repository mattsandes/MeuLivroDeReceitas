using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Communication.Usecases.User.Regsiter;

namespace MyRecipeBooks.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterUserJson request)
    {
        var usecase = new RegisterUserUseCase();

        var result = usecase.Execute(request);

        return Created(string.Empty, result);
    }
}