using System.Linq.Expressions;

namespace SocialRed.Core.Application.Interfaces.Repositories
{
    public interface IGenericsRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetAllWithInclude(Expression<Func<Entity, bool>> predicate);
        Task<Entity> GetById(int id);
        Task UpdateAsync(Entity entity, int id);
    }
}