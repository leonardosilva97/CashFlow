using System.Globalization;

namespace CashFlow.Api.Midlewere;

public class CultureMiddlewere
{
    private readonly RequestDelegate _next;
    public CultureMiddlewere(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedCultures = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("en");

        if (string.IsNullOrWhiteSpace(requestedCultures) == false
            && supportedLanguages.Exists(lenguage => lenguage.Name.Equals(requestedCultures))) { 
            cultureInfo = new CultureInfo(requestedCultures);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
