namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;

    public interface ITripsSevice
    {
        void Create(AddTripInputModel input);
    }
}
