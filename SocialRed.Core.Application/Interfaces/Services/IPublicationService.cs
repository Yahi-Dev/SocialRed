using SocialRed.Core.Application.Services;
using SocialRed.Core.Application.ViewModels.Publication;
using SocialRed.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IPublicationService : IGenericService<SavePublicationViewModel, PublicationViewModel, Publication>
    {
        Task<List<PublicationViewModel>> GetAllPublicationOfFriend(string IdUser);
        Task<List<PublicationViewModel>> GetAllPublicationOfUser(string UserId);
    }
}
