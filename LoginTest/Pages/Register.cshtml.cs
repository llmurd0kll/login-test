using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginTest.Models;
using LoginTest.Services;

namespace LoginTest.Pages
    {
    public class RegisterModel : PageModel
        {
        private readonly ISoapAuthService _auth;
        public RegisterModel(ISoapAuthService auth) => _auth = auth;

        [BindProperty] public RegisterInput Input { get; set; } = new();
        public AuthResult? Result { get; private set; }

        public async Task<IActionResult> OnPostAsync()
            {
            if (!ModelState.IsValid)
                return Page();
            Result = await _auth.RegisterAsync(Input.Email, Input.Password);
            return Page();
            }
        }
    }
