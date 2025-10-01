using System.Globalization;

namespace MyRecipeBooks.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var suportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        
        var cultureInfo = new CultureInfo("en");

        if (string.IsNullOrWhiteSpace(requestCulture) == false
            && suportedLanguages.Any(n => n.Name == requestCulture))
        {
            cultureInfo = new CultureInfo(requestCulture);
        }

        CultureInfo.CurrentUICulture = cultureInfo;
        
        CultureInfo.CurrentCulture = cultureInfo;

        await _next(context);
    }
}