namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ErrorOnValdiationException : MyRecipeBookException
{
    public IList<string> _ErrorMessages { get; set; }

    public ErrorOnValdiationException(IList<string> errorMessages)
    {
        _ErrorMessages = errorMessages;
    }
}