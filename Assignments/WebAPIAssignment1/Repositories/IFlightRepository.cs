using WebAPIAssignment1.Models;

namespace WebAPIAssignment1.Repositories
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlight(int id);
        void AddFlight(Flight flight);
        void EditFlight(Flight flight);
        void DeleteFlight(int id);
    }
}
