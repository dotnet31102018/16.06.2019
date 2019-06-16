using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Login
{
    public interface ILoginService
    {
        bool TryAdminLogin(string username, string password, out LoginToken<Administrator> token);
        bool TryAirlineLogin(string username, string password, out LoginToken<AirlineCompany> token);
        bool TryCustomerLogin(string username, string password, out LoginToken<Customer> token);
    }
}
