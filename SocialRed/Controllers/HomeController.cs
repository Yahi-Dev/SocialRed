using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Models;
using System.Diagnostics;
using SocialRed.Core.Application.Helpers;

namespace SocialRed.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IPublicationService _publicationService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IPublicationService publicationService)
        {
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _logger = logger;
            _publicationService = publicationService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _publicationService.GetAllPublicationOfUser(_userViewModel.Id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
