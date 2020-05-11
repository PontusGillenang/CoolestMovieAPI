using CoolestMovieAPI.MovieDbContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public class BaseRepository : IBaseRepository
    {

        protected readonly MovieContext _festivalContext;
        protected readonly ILogger<BaseRepository> _logger;

        public BaseRepository(MovieContext context, ILogger<BaseRepository> logger)
        {
            _festivalContext = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _festivalContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _festivalContext.Remove(entity);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _festivalContext.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _festivalContext.Update(entity);
        }

    }
}
