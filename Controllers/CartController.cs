using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data;
using MyECommerceApp.Models; 
using System.Security.Claims;
using System.Threading.Tasks;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> CartIndex()
    {
        var userId = GetCurrentUserId(); 
        var cart = await _context.Carts
            .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int cartId, int productId)
    {
        var cartProduct = await _context.CartProducts
            .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        
        if (cartProduct != null)
        {
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(CartIndex));
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int cartId, int productId, int quantity) {
        var cartProduct = await _context.CartProducts
            .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);

        if (cartProduct == null)
        {
            return NotFound();
        }

        if (quantity > 0) 
        {
            cartProduct.Quantity = quantity; 
        }

        else
        {
            return BadRequest("Quantity must be atleast 1");
        }

        _context.CartProducts.Update(cartProduct);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(CartIndex));
    }
}
