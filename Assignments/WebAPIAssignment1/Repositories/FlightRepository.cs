using WebAPIAssignment1.Models;

namespace WebAPIAssignment1.Repositories
{
    public class FlightRepository:IFlightRepository
    {
        private static List<Flight> flights = new List<Flight>();

        public IEnumerable<Flight> GetAllFlights()
        {
            return flights;
        }

        public Flight GetFlight(int id)
        {
            try
            {
                return flights.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddFlight(Flight flight)
        {
            try
            {
                flights.Add(flight);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditFlight(Flight flight)
        {
            try
            {
                var existing = flights.FirstOrDefault(f => f.Id == flight.Id);
                if (existing != null)
                {
                    existing.FlightCode = flight.FlightCode;
                    existing.Seat = flight.Seat;
                    existing.FlightType = flight.FlightType;
                    existing.Company = flight.Company;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteFlight(int id)
        {
            try
            {
                var flight = flights.FirstOrDefault(f => f.Id == id);
                if (flight != null)
                {
                    flights.Remove(flight);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
