using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data; // Replace with the actual namespace of your Data folder
using MyECommerceApp.Models; // Replace with the actual namespace of your Models folder
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
        var userId = GetCurrentUserId(); // Replace with actual method to get the current user ID
        var user = await _context.User.FindAsync(userId);
        
        if (user == null)
        {
            return NotFound();
        }

        var model = new User
        {
            UserId = user.UserId,
            UserName = user.UserName,
            UserEmail = user.UserEmail,
            Password = user.Password // In a real-world scenario, handle passwords securely
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserIndex(User model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.User.FindAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.UserEmail = model.UserEmail;
            user.Password = model.Password; // Handle passwords securely in a real-world scenario

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

    // Other actions
}