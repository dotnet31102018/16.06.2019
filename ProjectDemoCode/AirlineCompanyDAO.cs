using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.Login
{
    class AirlineCompanyDAO : IAirlineCompanyDAO
    {
        public AirlineCompany GetAirlineByName(string name)
        {
            // sql query: select from Airline where name='{name}'
            // if found
            return new AirlineCompany();
            // if not:
            //return null;
        }
    }
}
