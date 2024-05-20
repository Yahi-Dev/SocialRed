using Microsoft.EntityFrameworkCore;
using SocialRed.Core.Application.Interfaces.Repositories;
using SocialRed.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace SocialRed.Infrastructure.Persistence.Repositories
{
    public class GenericsRepository<Entity> : IGenericsRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbcontext;


        public GenericsRepository(ApplicationContext applicationContext)
        {
            _dbcontext = applicationContext;
        }


        //Agregar
        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _dbcontext.Set<Entity>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }


        //Editar
        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            Entity entry = await _dbcontext.Set<Entity>().FindAsync(id);
            _dbcontext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbcontext.SaveChangesAsync();
        }


        //Borrar
        public virtual async Task DeleteAsync(Entity entity)
        {
            _dbcontext.Set<Entity>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        //Obtener por ID
        public virtual async Task<Entity> GetById(int id)
        {
            return await _dbcontext.Set<Entity>().FindAsync(id);
        }


        //Obtener todos las publicaciones
        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbcontext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<List<Entity>> GetAllWithInclude(Expression<Func<Entity, bool>> predicate)
        {
            return await _dbcontext.Set<Entity>().Where(predicate).ToListAsync();
        }
    }
}
