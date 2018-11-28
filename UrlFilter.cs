using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

public class UrlFilter : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    ILogger<UrlFilter> log = (ILogger<UrlFilter>)context.HttpContext.RequestServices.GetService(typeof(ILogger<UrlFilter>));
      log.LogInformation($"{context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");

  }
  public override void OnActionExecuted(ActionExecutedContext context)
  {
    ILogger<UrlFilter> log = (ILogger<UrlFilter>)context.HttpContext.RequestServices.GetService(typeof(ILogger<UrlFilter>));
      log.LogInformation($"{context.Controller.GetType().Name} - {context.ActionDescriptor.DisplayName}");
  }


}