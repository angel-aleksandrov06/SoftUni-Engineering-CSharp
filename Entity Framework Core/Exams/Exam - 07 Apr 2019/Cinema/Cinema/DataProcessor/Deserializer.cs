namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Cinema.XMLHelper;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportMoviesDTO[] importMoviesDTOs = JsonConvert.DeserializeObject<ImportMoviesDTO[]>(jsonString);

            List<Movie> movies = new List<Movie>();

            foreach (var importMovieDTO in importMoviesDTOs)
            {
                if (!IsValid(importMovieDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (movies.Any(x => x.Title == importMovieDTO.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse(typeof(Genre), importMovieDTO.Genre, out object genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = importMovieDTO.Title,
                    Genre = (Genre)Enum.Parse(typeof(Genre), importMovieDTO.Genre),
                    Duration = importMovieDTO.Duration,
                    Rating = importMovieDTO.Rating,
                    Director = importMovieDTO.Director
                };

                movies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportHallAndSeatDTO[] hallAndSeatDTOs = JsonConvert.DeserializeObject<ImportHallAndSeatDTO[]>(jsonString);

            List<Hall> halls = new List<Hall>();

            foreach (var hallSeatDTO in hallAndSeatDTOs)
            {
                if (!IsValid(hallSeatDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallSeatDTO.Name,
                    Is4Dx = hallSeatDTO.Is4Dx,
                    Is3D = hallSeatDTO.Is3D,
                };

                for (int i = 0; i < hallSeatDTO.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                var projectionType = "";

                if (hall.Is4Dx)
                {
                    projectionType = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    projectionType = "3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            ImportProjectionDTO[] importProjectionsDTOs = XmlConverter.Deserializer<ImportProjectionDTO>(xmlString, "Projections");

            var projections = new List<Projection>();

            foreach (var projectionDto in importProjectionsDTOs)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isMovieIdValid = context.Movies.Any(x => x.Id == projectionDto.MovieId);
                var isHallIdValid = context.Halls.Any(x => x.Id == projectionDto.HallId);

                if (!isMovieIdValid || !isHallIdValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Projection projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                sb.AppendLine(String.Format(
                    SuccessfulImportProjection, 
                    context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId).Title,
                    projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                    ));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            ImportCustomerDTO[] importCustomerDTOs = XmlConverter.Deserializer<ImportCustomerDTO>(xmlString, "Customers");
            var projectionIds = context.Projections.Select(x => x.Id).ToArray();

            var customers = new List<Customer>();

            foreach (var customerDTO in importCustomerDTOs)
            {
                if (!IsValid(customerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var boolean = true;
                foreach (var ticket in customerDTO.Tickets)
                {
                    if (!projectionIds.Contains(ticket.ProjectionId))
                    {
                        boolean = false;
                        break;
                    }
                }

                if  (boolean == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!customerDTO.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDTO.FirstName,
                    LastName = customerDTO.LastName,
                    Age = customerDTO.Age,
                    Balance = customerDTO.Balance,
                };

                foreach (var ticket in customerDTO.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticket.ProjectionId,
                        Price = ticket.Price
                    });
                }

                customers.Add(customer);
                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}