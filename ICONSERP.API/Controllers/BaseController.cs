using ICONSERP.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ICONSERP.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private bool success;
        private string message;

        protected bool IsModelStateValid()
        {
            if (!ModelState.IsValid)
            {
                success = false;
                message = string.Join(", ", ModelState.Values.SelectMany(e => e.Errors).Select(e => string.Format("{0}{1}{2}", e.Exception, (string.IsNullOrEmpty(e.Exception?.GetInnerMessage()) || string.IsNullOrEmpty(e.ErrorMessage) ? "" : " - "), e.ErrorMessage)).ToList());
                return false;
            }
            return true;
        }


    }
}
