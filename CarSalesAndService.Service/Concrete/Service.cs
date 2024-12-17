using CarSalesAndService.Data;
using CarSalesAndService.Data.Concrete;
using CarSalesAndService.Entities;

namespace CarSalesAndService.Service.Concrete
{
    public class Service<T> : Repository<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}
