namespace MyRecipeBook.Communication.Responses;

public class ResponseErrorJson
{
    public IList<string> _errorMessages { get; set; }

    public ResponseErrorJson(IList<string> errorMessages) => _errorMessages = errorMessages;
    public ResponseErrorJson(string errorMessage)
    {
        _errorMessages = new List<string>
        {
            errorMessage
        };
    }
}