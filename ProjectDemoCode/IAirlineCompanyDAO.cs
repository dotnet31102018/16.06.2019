namespace FinalProj.Login
{
    public interface IAirlineCompanyDAO
    {
        AirlineCompany GetAirlineByName(string name);

    }
}