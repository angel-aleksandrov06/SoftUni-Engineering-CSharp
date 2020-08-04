namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
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
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}