namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using MusicHub.XMLHelper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportWriterDTO[] importWritersDTOs = JsonConvert.DeserializeObject<ImportWriterDTO[]>(jsonString);

            var writers = new List<Writer>();

            foreach (var importWriterDto in importWritersDTOs)
            {
                if (!IsValid(importWriterDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = importWriterDto.Name,
                    Pseudonym = importWriterDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            List<Producer> producers = new List<Producer>();

            ImportProducerDTO[] importProducerDTOs = JsonConvert.DeserializeObject<ImportProducerDTO[]>(jsonString);

            foreach (var importProducerDTO in importProducerDTOs)
            {
                var isAlbumCorrect = true;

                if (!IsValid(importProducerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Producer producer = new Producer
                {
                    Name = importProducerDTO.Name,
                    Pseudonym = importProducerDTO.Pseudonym,
                    PhoneNumber = importProducerDTO.PhoneNumber
                };

                foreach (var importAlbum in importProducerDTO.Albums)
                {
                    if (!IsValid(importAlbum))
                    {
                        sb.AppendLine(ErrorMessage);
                        isAlbumCorrect = false;
                        break;
                    }

                    Album album = new Album
                    {
                        Name = importAlbum.Name,
                        ReleaseDate = DateTime.ParseExact(importAlbum.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                if (!isAlbumCorrect)
                {
                    continue;
                }

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(String.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var songs = new List<Song>();
            var albumsIds = context.Albums.Select(x => x.Id).ToArray();
            var writerIds = context.Writers.Select(x => x.Id).ToArray();

            ImportSongDTO[] importSongDTOs = XmlConverter.Deserializer<ImportSongDTO>(xmlString, "Songs");

            foreach (var importSongDTO in importSongDTOs)
            {
                if (!IsValid(importSongDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!albumsIds.Any(x => importSongDTO.AlbumId == x))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!writerIds.Any(x => importSongDTO.WriterId == x))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                bool isGenreCurrectly = Enum.TryParse(typeof(Genre), importSongDTO.Genre, out object genre);

                if (!isGenreCurrectly)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Song song = new Song
                {
                    Name = importSongDTO.Name,
                    Duration = TimeSpan.ParseExact(importSongDTO.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(importSongDTO.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = (Genre)genre,
                    AlbumId = importSongDTO.AlbumId,
                    WriterId = importSongDTO.WriterId,
                    Price = importSongDTO.Price
                };

                songs.Add(song);
                sb.AppendLine(String.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration.ToString()));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var performers = new List<Performer>();
            var songIds = context.Songs.Select(x => x.Id).ToArray();

            ImportSongPerformerDTO[] importSongPerformerDTOs = XmlConverter.Deserializer<ImportSongPerformerDTO>(xmlString, "Performers");

            foreach (var importSongPerformerDTO in importSongPerformerDTOs)
            {
                var isSongIdCorrectly = true;

                if (!IsValid(importSongPerformerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Performer performer = new Performer
                {
                    FirstName = importSongPerformerDTO.FirstName,
                    LastName = importSongPerformerDTO.LastName,
                    Age = importSongPerformerDTO.Age,
                    NetWorth = importSongPerformerDTO.NetWorth
                };

                foreach (var songDTO in importSongPerformerDTO.PerformerSongs)
                {
                    if (!songIds.Any(x => songDTO.Id == x))
                    {
                        sb.AppendLine(ErrorMessage);
                        isSongIdCorrectly = false;
                        break;
                    }

                    SongPerformer songPerformer = new SongPerformer
                    {
                        SongId = songDTO.Id
                    };

                    performer.PerformerSongs.Add(songPerformer);
                }

                if (isSongIdCorrectly == false)
                {
                    continue;
                }

                performers.Add(performer);
                sb.AppendLine(String.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
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