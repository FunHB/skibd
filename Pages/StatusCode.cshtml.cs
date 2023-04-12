using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace skibd.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class StatusCodeModel : PageModel
{
    public int OriginalStatusCode { get; set; }

    public string? OriginalPathAndQuery { get; set; }

    public void OnGet(int statusCode)
    {
        OriginalStatusCode = statusCode;

        var statusCodeReExecuteFeature =
            HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

        

        if (statusCodeReExecuteFeature is not null)
        {
            OriginalPathAndQuery = string.Join(
                statusCodeReExecuteFeature.OriginalPathBase,
                statusCodeReExecuteFeature.OriginalPath,
                statusCodeReExecuteFeature.OriginalQueryString);
        }
    }

    public string GetStatusCodeMessage(int? statusCode = null)
    {
        statusCode ??= OriginalStatusCode;

        if (statusCode == 400) return "Bad Request.";

        if (statusCode == 401) return "Unauthorized.";

        if (statusCode == 403) return "Forbidden.";

        if (statusCode == 404) return "Not Found.";

        if (statusCode == 405) return "Method Not Allowed";

        if (statusCode == 500) return "Internal Server Error.";

        return "";
    }
}
