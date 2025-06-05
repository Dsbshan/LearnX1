using AuthIservices.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyAuthApp.Controllers
{
    public class DashboardController : BaseController
    {

        private readonly IMasterDataRepositoy _masterDataRepositoy;

        public DashboardController(IMasterDataRepositoy masterDataRepositoy) {
            _masterDataRepositoy = masterDataRepositoy;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]

        public Response GetModulesLists() 
        {
            try
            {
                var ModulesList = _masterDataRepositoy.GetModulesLists();
                return ReturnSuccess(ModulesList, true, "001");
          }
            catch (Exception ex){

               return ReturnError(ex, "002", ModelState);
            
            }
        
        }
    }
}
