using AuthIservices;
using AuthIservices.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyAuthApp.Controllers
{

    [Authorize]
    public class NotebookController : BaseController
    {


        private readonly IDiaryRepository _diaryRepo;
        private readonly IUserRepository _userRepo;


        public NotebookController(IDiaryRepository diaryRepo, IUserRepository userRepo)
        {
            _diaryRepo = diaryRepo;
            _userRepo = userRepo;
        }

        public ActionResult Note()
        {
            return View();
        }

        [HttpPost]
        public Response CreateNote(DiaryEntry diary)
        {
            try
            {
                
                var userEmail = User.Identity.Name;
                var user = _userRepo.GetUserByEmail(userEmail);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                diary.UserId = user.UserId;

                var entryId = _diaryRepo.CreateNote(diary);
                return ReturnSuccess(entryId, true, "001");
            }
            catch (Exception ex)
            {
                return ReturnError(ex, "002", ModelState);
            }
        }






    }
    }
