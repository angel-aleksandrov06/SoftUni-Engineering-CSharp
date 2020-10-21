namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Globalization;

    public class TripsSevice : ITripsSevice
    {
        private readonly ApplicationDbContext db;

        public TripsSevice(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddTripInputModel input)
        {
            var dbTrip = new Trip
            {
                DepartureTime = DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = input.Description,
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                ImagePath = input.ImagePath,
                Seats = (byte)input.Seats,
            };

            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }
    }
}
