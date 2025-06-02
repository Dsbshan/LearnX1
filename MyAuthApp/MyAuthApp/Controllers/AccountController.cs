using AuthIservices.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAuthApp.Controllers;
using System.Security.Claims;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

public class AccountController : BaseController
{
    private readonly IUserRepository _userRepo;

    public AccountController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public ActionResult Login()
    {
        return View();
    }

    public ActionResult Register()
    {
        return View();
    }



    [HttpPost]
    public async Task<Response> Login(UserModel usrl)
    {
        try
        {
            var user = _userRepo.Login(usrl);
            if (user == null)
                throw new Exception("Invalid email or password.");
            HttpContext.Session.SetString("Email", user.Email);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
        };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return ReturnSuccess(user, true, "005");
        }
        catch (Exception ex)
        {
            return ReturnError(ex, "002", ModelState);
        }
    }



    [HttpPost]
    public Response Register(UserModel model)
    {
        try
        {
            var userId = _userRepo.Register(model);
            return ReturnSuccess(userId, true, "001");
        }
        catch (Exception ex)
        {
            return ReturnError(ex, "002", ModelState);
        }
    }

    [HttpGet]

    public Response GetUserByEmail(string Email)
    {
        try
        {
            var getId = _userRepo.GetUserByEmail(Email);
            return ReturnSuccess(getId, true, "001");
        }
        catch(Exception ex) 
        {
            return ReturnError(ex, "002", ModelState);
         
        }
    }
    





    public async Task<ActionResult> Logout()
    {
        HttpContext.Session.Clear();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}
