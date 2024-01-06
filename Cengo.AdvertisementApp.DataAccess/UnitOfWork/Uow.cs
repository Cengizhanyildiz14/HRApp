using Cengo.AdvertisementApp.DataAccess.Contexts;
using Cengo.AdvertisementApp.DataAccess.Interfaces;
using Cengo.AdvertisementApp.DataAccess.Repositories;
using Cengo.AdvertisementApp.Entities;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepostitory<T> GetRepostitory<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
