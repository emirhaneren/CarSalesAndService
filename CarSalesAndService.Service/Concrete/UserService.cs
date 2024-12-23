using CarSalesAndService.Data;
using CarSalesAndService.Data.Concrete;
using CarSalesAndService.Service.Abstract;

namespace CarSalesAndService.Service.Concrete
{
    public class UserService : UserRepository,IUserService
    {
        public UserService(DatabaseContext context) : base(context)
        {
        }
    }
}
