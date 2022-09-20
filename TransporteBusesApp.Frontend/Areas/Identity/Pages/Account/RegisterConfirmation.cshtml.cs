using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TransporteBusesApp.Frontend.Areas.Identity.Pages.Account
{
    public class RegisterConfirmation : PageModel
    {
        private readonly ILogger<RegisterConfirmation> _logger;

        public RegisterConfirmation(ILogger<RegisterConfirmation> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}