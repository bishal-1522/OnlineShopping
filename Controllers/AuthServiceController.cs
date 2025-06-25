using Microsoft.AspNetCore.Mvc;
using MVCEcommerce.Models.DTO;
using MVCEcommerce.Services;

namespace MVCEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController(IAuthService authService) : Controller
    {
        [HttpPost("register")]

        public async Task<IActionResult> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user == null)
            {
                ModelState.AddModelError("", "User name already exists");
                return View(); 
            }

            return View("Success", user); 
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var result = await authService.LoginAsync(request);
            if (result == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View("Login"); // Re-render the login view with error
            }

            return View("Dashboard", result); // Show a success page/view
        }





    }
}
