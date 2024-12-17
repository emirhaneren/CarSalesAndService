using CarSalesAndService.Data;
using CarSalesAndService.Data.Concrete;
using CarSalesAndService.Entities;
using CarSalesAndService.Service.Abstract;

namespace CarSalesAndService.Service.Concrete
{
    public class Service<T> : Repository<T>,IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}
