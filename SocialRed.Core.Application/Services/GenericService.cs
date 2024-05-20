using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Core.Application.Interfaces.Services;
using System.Linq.Expressions;

namespace SocialRed.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
          where ViewModel : class
          where Entity : class
    {
        private readonly IGenericsRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericsRepository<Entity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual async Task Update(SaveViewModel viewModel, int id)
        {
            Entity entity = _mapper.Map<Entity>(viewModel);
            await _repository.UpdateAsync(entity, id);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var entitylist = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entitylist);
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel viewModel)
        {
            Entity entity = _mapper.Map<Entity>(viewModel);
            entity = await _repository.AddAsync(entity);
            SaveViewModel Savevm = _mapper.Map<SaveViewModel>(entity);
            return Savevm;
        }


        public virtual async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Entity entity = await _repository.GetById(id);

            SaveViewModel Savevm = _mapper.Map<SaveViewModel>(entity);
            return Savevm;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.GetById(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
