using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace studentprojectMVC.Views.Home
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostWithdraw()
        {
            HttpContext.Features.Get<ITrackingConsentFeature>().WithdrawConsent();
            return RedirectToPage("./Index");
        }
    }
}
