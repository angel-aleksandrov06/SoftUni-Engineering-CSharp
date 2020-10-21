namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Globalization;

    public class TripsController : Controller
    {
        private readonly ITripsSevice tripsSevice;

        public TripsController(ITripsSevice tripsSevice)
        {
            this.tripsSevice = tripsSevice;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/User/Login");
            }

            var trips = this.tripsSevice.GetAll();

            return this.View(trips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/User/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/User/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Error("Start point is required.");
            }

            if (string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Error("End point is required.");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length > 80)
            {
                return this.Error("Description is required and has max length of 80 characters.");
            }

            if (!DateTime.TryParseExact(
                input.DepartureTime, 
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out _))
            {
                return this.Error("Invalid departureTime. Please use dd.MM.yyyy HH:mm format.");
            }

            this.tripsSevice.Create(input);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/User/Login");
            }

            var tripDetails = this.tripsSevice.GetDetails(tripId);
            return this.View(tripDetails);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsSevice.HasAvailableSeats(tripId))
            {
                return this.Error("No seats available.");
            }

            var userId = this.GetUserId();
            var IsUserAdded = this.tripsSevice.AddUserToTrip(userId, tripId);
            if (!IsUserAdded)
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }
            return this.Redirect("/Trips/All");
        }
    }
}
