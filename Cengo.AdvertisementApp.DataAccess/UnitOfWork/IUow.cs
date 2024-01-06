using Cengo.AdvertisementApp.DataAccess.Interfaces;
using Cengo.AdvertisementApp.Entities;
using System.Threading.Tasks;

namespace Cengo.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepostitory<T> GetRepostitory<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
