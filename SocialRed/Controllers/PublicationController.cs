using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.ViewModels.Muro;
using SocialRed.Core.Application.ViewModels.Publication;
using Microsoft.AspNetCore.Authorization;

namespace SocialRed.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IUserService _userService;
        public PublicationController(IPublicationService publicationService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _publicationService = publicationService;
            _userService = userService;

        }
        public async Task<IActionResult> Create()
        {
            SavePublicationViewModel vm = new();
            return View("SavePublication", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(SavePublicationViewModel vm)
        {
            var p = await _userService.GetByIdUserAsync(_userViewModel.Id);

            if (vm.FileImg != null)
            {
                vm.ImagePublication = UploadFile(vm.FileImg, p.UserName);
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _publicationService.Add(vm);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            SavePublicationViewModel vm = await _publicationService.GetByIdSaveViewModel(id);
            return View("SavePublication", vm);
        }


        [HttpPost]
        public async Task<IActionResult> EditPost(SavePublicationViewModel vm)
        {
            if (vm.FileImg != null)
            {
                vm.ImagePublication = UploadFile(vm.FileImg, _userViewModel.Username);
            }
            if (!ModelState.IsValid)
            {
                return View("SavePublication", vm);
            }
            await _publicationService.Update(vm, vm.Id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _publicationService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _publicationService.Delete(id);

            string basePath = $"/Images/Publications/{_userViewModel.Username}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
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
            string basePath = $"/Images/Publications/{username}";
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
