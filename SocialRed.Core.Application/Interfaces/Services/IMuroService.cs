using SocialRed.Core.Application.ViewModels.Comment;
using SocialRed.Core.Application.ViewModels.Muro;
using SocialRed.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IMuroService : IGenericService<SaveMuroViewModel, MuroViewModel, Muro>
    {
        Task<List<MuroViewModel>> GetAllViewModelWithInclude();
    }
}
