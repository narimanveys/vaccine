using System.Web.Mvc;
using NLog;

namespace PattientVaccinationApp.ActionFilters
{
    public class LogActionAttribute : ActionFilterAttribute, IActionFilter
    {
        #region Fields 

        private readonly ILogger _logger= LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.Info(filterContext.ActionDescriptor.ActionName);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            _logger.Info(filterContext.ActionDescriptor.ActionName + " Метод завершил свою работу");
            if (filterContext.Exception != null)
            {
                _logger.Error(filterContext.Exception);
            }
        }

        #endregion

    }
}