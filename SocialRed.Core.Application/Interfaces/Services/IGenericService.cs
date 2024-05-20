using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        Task<List<ViewModel>> GetAllViewModel();
        Task Update(SaveViewModel viewModel, int id);
        Task<SaveViewModel> Add(SaveViewModel viewModel);
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task Delete(int id);
    }
}
