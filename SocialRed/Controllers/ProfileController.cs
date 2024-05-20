using Microsoft.AspNetCore.Mvc;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;

namespace SocialRed.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMuroService _muroService;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IUserService _userService;
        public ProfileController(IMuroService muroService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _muroService = muroService;
            _userService = userService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _muroService.GetAllViewModelWithInclude());
        }


        public async Task<IActionResult> EditInfoAccount()
        {
            return View("EditInfoAccount", await _userService.GetByIdUserAsync(_userViewModel.Id));
        }


        [HttpPost]
        public async Task<IActionResult> EditInfoAccount(SaveUserViewModel vm)
        {
            vm.IdUser = _userViewModel.Id;
            if (vm.FileImg != null)
            {
                vm.ImageProfile = UploadFile(vm.FileImg, vm.UserName, true, _userViewModel.ImageProfile);
            }
            if (!ModelState.IsValid && vm.Email == null)
            {
                return View(vm);
            }
            await _userService.UpdateInfoAccount(vm);
            return RedirectToRoute(new { controller = "Profile", action = "Index" });
        }

        private string UploadFile(IFormFile file, string username, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            string basePath = $"/Images/Users/{username}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }
    }
}
