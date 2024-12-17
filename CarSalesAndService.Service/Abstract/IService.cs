using CarSalesAndService.Entities;
using CarSalesAndService.Data.Abstract;

namespace CarSalesAndService.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
