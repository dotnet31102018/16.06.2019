using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Login
{
    public class LoginService : ILoginService
    {
        private AirlineCompanyDAO _airlineCompanyDAO;

        public LoginService()
        {
            _airlineCompanyDAO = new AirlineCompanyDAO();
        }

        public bool TryAdminLogin(string username, string password, out LoginToken<Administrator> token)
        {
            if (username.ToUpper() == FlightCenterConfig.ADMIN_NAME && password == FlightCenterConfig.ADMIN_PASSWORD)
            {
                token = new LoginToken<Administrator>();
                token.User = new Administrator();
                return true;
            }
            
            token = null;
            return false;
        }

        public bool TryAirlineLogin(string username, string password, out LoginToken<AirlineCompany> token)
        {
            AirlineCompany company = _airlineCompanyDAO.GetAirlineByName(username);
            if (company != null)
            {
                if (company.Password == password)
                {
                    token = new LoginToken<AirlineCompany>() { User = company };
                    return true;
                }
                // wrong passowrd exception
                // catch
            }
            token = null;
            return false;
        }

        public bool TryCustomerLogin(string username, string password, out LoginToken<Customer> token)
        {
            throw new NotImplementedException();
        }
    }
}
