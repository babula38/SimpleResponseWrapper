using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SimpleResponseWrapper
{
    public class ResponseWrapperActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result)
            {
                Result responseResult = new(result.StatusCode, result.Value);

                context.Result = new ObjectResult(responseResult);
            }
        }
    }
}
