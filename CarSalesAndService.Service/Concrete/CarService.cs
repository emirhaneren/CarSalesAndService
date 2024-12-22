using CarSalesAndService.Data;
using CarSalesAndService.Data.Concrete;
using CarSalesAndService.Service.Abstract;

namespace CarSalesAndService.Service.Concrete
{
    public class CarService : CarRepository, ICarService
    {
        public CarService(DatabaseContext context) : base(context)
        {
        }
    }
}
