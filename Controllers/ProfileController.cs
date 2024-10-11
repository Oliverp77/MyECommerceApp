using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data; 
using MyECommerceApp.Models; 
using System.Security.Claims;
using System.Threading.Tasks;

public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> UserIndex()
    {
        var userId = GetCurrentUserId();
        var user = await _context.Users.FindAsync(userId);
        
        if (user == null)
        {
            return NotFound();
        }

        var model = new UserProfileViewModel
        {
            UserId = user.UserId,
            CurrentName = user.Name,
            CurrentEmail = user.Email,
            NewName = string.Empty,
            NewEmail = string.Empty
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserIndex(UserProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FindAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.NewName))
        {
            user.Name = model.NewName;
        }

        if (!string.IsNullOrEmpty(model.NewEmail))
        {
            user.Email = model.NewEmail;
        }

        if (!string.IsNullOrEmpty(model.NewPassword) && user.Password == model.CurrentPassword)
        {
            user.Password = model.NewPassword; 
        }

        if (user.Password != model.CurrentPassword)
        {
            ModelState.AddModelError("CurrentPassword", "The current password is incorrect.");
            return View(model);
        }

            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
    }


}
