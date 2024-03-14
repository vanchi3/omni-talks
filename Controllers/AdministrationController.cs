using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OmniTalks.Data;
using OmniTalks.Models;
using OmniTalks.Models.Domein;
using System;
using System.Security.Claims;

namespace OmniTalks.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> signInManager;

        private readonly ApplicationDbContext context;

        public AdministrationController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext _context)
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this.context = _context;
            Console.WriteLine("User Id: " + User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine("Username: " + User.FindFirstValue(ClaimTypes.Name));
        }

        //[HttpGet]
        //public async Task<IActionResult> ManageUserClaims(string UserId)
        //{
        //    //First, fetch the User Details Based on the UserId
        //    var user = await _userManager.FindByIdAsync(UserId);
        //
        //    if (user == null)
        //    {
        //        //handle if the User is not Exists in the database
        //        ViewBag.ErrorMessage = $"User with Id = {UserId} cannot be found";
        //        return View("NotFound");
        //    }
        //
        //    //Storing the UserName in the ViewBag for Display Purpose
        //    ViewBag.UserName = user.UserName;
        //
        //    //Create UserClaimsViewModel Instance
        //    var model = new UserClaimViewModel
        //    {
        //        UserId = UserId
        //    };
        //
        //    // UserManager service GetClaimsAsync method gets all the current claims of the user
        //    var existingUserClaims = await _userManager.GetClaimsAsync(user);
        //
        //    // Loop through each claim we have in our application
        //    // Call the GetAllClaims Static Method ClaimsStore Class
        //    foreach (Claim claim in ClaimsStore.GetAllClaims())
        //    {
        //        //Create an Instance of UserClaim class
        //        UserClaim userClaim = new UserClaim
        //        {
        //            ClaimType = claim.Type
        //        };
        //
        //        // If the user has the claim, set IsSelected property to true, so the checkbox
        //        // next to the claim is checked on the UI
        //        if (existingUserClaims.Any(c => c.Type == claim.Type))
        //        {
        //            userClaim.IsSelected = true;
        //        }
        //        //By default the IsSelected is False, no need to set as false
        //
        //        //Add the userClaim to UserClaimsViewModel Instance 
        //        model.Cliams.Add(userClaim);
        //    }
        //
        //    return RedirectToAction("Home", "Index",model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> ManageUserClaims(UserClaimViewModel model)
        //{
        //    //First fetch the User Details
        //    var user = await _userManager.FindByIdAsync(model.UserId);
        //
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
        //        return View("NotFound");
        //    }
        //
        //    // Get all the user existing claims and delete them
        //    var claims = await _userManager.GetClaimsAsync(user);
        //    var result = await _userManager.RemoveClaimsAsync(user, claims);
        //
        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot remove user existing claims");
        //        return View(model);
        //    }
        //
        //    // Add all the claims that are selected on the UI
        //    var AllSelectedClaims = model.Cliams.Where(c => c.IsSelected)
        //                .Select(c => new Claim(c.ClaimType, c.ClaimType))
        //                .ToList();
        //
        //    //If At least 1 Claim is assigned, Any Method will return true
        //    if (AllSelectedClaims.Any())
        //    {
        //        //add a user to multiple claims simultaneously
        //        result = await _userManager.AddClaimsAsync(user, AllSelectedClaims);
        //
        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", "Cannot add selected claims to user");
        //            return View(model);
        //        }
        //    }
        //
        //    return RedirectToAction("EditUser", new { UserId = model.UserId });
        //}
    }
}
