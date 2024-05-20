using AutoMapper;
using Microsoft.AspNetCore.Http;
using SocialRed.Core.Application.DTOs.Account;
using SocialRed.Core.Application.Helpers;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Application.Interfaces.Services;
using SocialRed.Core.Application.ViewModels.Muro;
using SocialRed.Core.Application.ViewModels.Publication;
using SocialRed.Core.Domain.Entities;

namespace SocialRed.Core.Application.Services
{
    public class MuroService : GenericService<SaveMuroViewModel, MuroViewModel, Muro>, IMuroService
    {
        private readonly IMuroRepository _muroRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse _userViewModel;
        private readonly IMapper _mapper;

        public MuroService
        (IMuroRepository muroRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
        : base(muroRepository, mapper)
        {
            _muroRepository = muroRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _mapper = mapper;
        }


        public override async Task<SaveMuroViewModel> Add(SaveMuroViewModel vm)
        {
            vm.IdOfUserPublication = _userViewModel.Id;
            vm.UserNameOfUserPublication = _userViewModel.Username;
            vm.Created = DateTime.Now;
            vm.CreateBy = _userViewModel.Username;
            if (vm.UrlVideoPublication == null)
            {
                vm.UrlVideoPublication = "None";
            }
            var SavedVm = await base.Add(vm);
            return SavedVm;
        }

        public override async Task Update(SaveMuroViewModel vm, int id)
        {
            if (vm.UrlVideoPublication == null)
            {
                vm.UrlVideoPublication = "None";
            }
            vm.IdOfUserPublication = _userViewModel.Id;
            vm.UserNameOfUserPublication= _userViewModel.Username;
            await base.Update(vm, id);
        }

        public async Task<List<MuroViewModel>> GetAllViewModelWithInclude()
        {
            var productlist = await _muroRepository.GetAllWithInclude(p => p.IdOfUserPublication == _userViewModel.Id);

            List<MuroViewModel> vms = new();


            foreach (var item in productlist)
            {
                var vm = _mapper.Map<MuroViewModel>(item);
                vms.Add(vm);
            }
            return vms;
        }
    }
}
