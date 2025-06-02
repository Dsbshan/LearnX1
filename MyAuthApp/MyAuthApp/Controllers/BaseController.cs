using AuthIservices.Entities;
using AuthIservices.Message;
using Microsoft.AspNetCore.Mvc;

namespace MyAuthApp.Controllers
{
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {
        public Response ReturnSuccess(Object result)
        {
            Response res = new Response();
            res.Result = result;
            res.IsSuccess = true;
            return res;
        }

        public Response ReturnError(Exception ex)
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
        public Response ReturnError(Exception ex, string messageCode, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            MessageBL message = new MessageBL();
            Response res = new Response();
            //When release need to change
            if (ex is AppException)
            {
                res.Message = message.GetMessage(ex.Message);
            }
            else
            {
                res.Message = ex.Message.ToString();
            }
            res.Result = null;
            res.IsSuccess = false;
            return res;
        }
    }
}
