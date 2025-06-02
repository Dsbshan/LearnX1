
using CImplementation.Services;
using CInfrastructure.Base;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuh.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        public Response ReturnSuccess(Object result)
        {
            Response res = new Response();
            res.Result = result;
            res.IsSuccess = true;
            return res;
        }

        public Response ReturnError(Exception ex, string v, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            Response res = new Response();
            res.Result = null;
            res.Message = ex.Message.ToString();
            res.IsSuccess = false;
            return res;
        }
        public Response ReturnSuccess(Object result, bool messageShow, string messageCode)
        {
            MessageBL message = new MessageBL();
            Response res = new Response();
            res.Result = result;
            res.IsSuccess = true;
            res.MessageShow = messageShow;
            res.Message = message.GetMessage(messageCode);
            return res;
        }
    }
}
