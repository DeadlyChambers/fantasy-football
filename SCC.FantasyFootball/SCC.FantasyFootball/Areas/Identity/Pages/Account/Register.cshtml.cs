using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SCC.FantasyFootball.Areas.Identity.Data;

namespace SCC.FantasyFootball.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<SCCUser> _signInManager;
        private readonly UserManager<SCCUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
     //   RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<SCCUser> userManager,
     //       RoleManager<IdentityRole> roleManager,
            SignInManager<SCCUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            // _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

    //    public async Task CreateRole(SCCRoles sccRole)
    //    {
    //        bool x = await _roleManager.RoleExistsAsync(sccRole.ToString());
    //        if (!x)
    //        {
    //            // first we create Admin role 
    //            var role = new IdentityRole
    //            {
    //                Name = sccRole.ToString()
    //};
    //            await _roleManager.CreateAsync(role);
    //        }
    //    }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var rolesToAdd = new List<string> { SCCRoles.Reader.ToString() };
                if (Input.Email.Equals("shanechambers85@gmail.com", StringComparison.OrdinalIgnoreCase))
                   rolesToAdd.Add( SCCRoles.Admin.ToString());
                if (Input.Email.Contains("85"))
                    rolesToAdd.Add( SCCRoles.Contributor.ToString());
                var user = new SCCUser { UserName = Input.Email, Email = Input.Email, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    var roleresult = await _userManager.AddToRolesAsync(user, rolesToAdd);
                    {
                        _logger.LogDebug($"Added user roles of {string.Join(",",rolesToAdd)} on registration");
                    }
                    //var creationClaims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name, user.UserName),
                    //    new Claim(ClaimTypes.Role, createdUserRole.ToString()),
                    //    new Claim(ClaimTypes.Email, user.UserName)
                    //};
                    //var claims = await _userManager.AddClaimsAsync(user, creationClaims);
                    //if (claims.Succeeded)
                    //{
                    //    _logger.LogDebug($"Added claims for {user.UserName} on registration");
                    //}
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {   
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirm = await _userManager.ConfirmEmailAsync(user, code);

                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: true);
                        return LocalRedirect(returnUrl);
                    }
                }
               
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
