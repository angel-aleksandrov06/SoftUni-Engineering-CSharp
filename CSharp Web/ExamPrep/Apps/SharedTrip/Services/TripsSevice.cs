namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripsSevice : ITripsSevice
    {
        private readonly ApplicationDbContext db;

        public TripsSevice(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);

            if (userInTrip)
            {
                return false;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;

            return availableSeats > 0;
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

        public IEnumerable<TripViewModel> GetAll()
        {
            return this.db.Trips.Select(x => new TripViewModel
            {
                DepartureTime = x.DepartureTime,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                Id = x.Id,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count()
            }).ToList();
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            return this.db.Trips.Where(x => x.Id == id)
                .Select( x => new TripDetailsViewModel
                {
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    UsedSeats = x.UserTrips.Count(),
                })
                .FirstOrDefault();
        }
    }
}
