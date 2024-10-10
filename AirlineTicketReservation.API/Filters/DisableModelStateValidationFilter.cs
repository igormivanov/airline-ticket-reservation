using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketReservation.API.Filters {
    public class DisableModelStateValidationFilter : IActionFilter {
        public void OnActionExecuting(ActionExecutingContext context) {

            if (context.ModelState.IsValid == false) {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }

}
