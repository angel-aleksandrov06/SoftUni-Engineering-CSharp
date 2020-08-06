namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using MusicHub.XMLHelper;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToArray()
               .Where(x => x.ProducerId == producerId)
               .Select(x => new
               {
                   AlbumName = x.Name,
                   ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                   ProducerName = x.Producer.Name,
                   Songs = x.Songs
                   .ToArray()
                   .Select(z => new
                        {
                            SongName = z.Name,
                            Price = z.Price.ToString("f2"),
                            Writer = z.Writer.Name
                        })
                        .OrderByDescending(z => z.SongName)
                        .ThenBy(z => z.Writer)
                        .ToArray(),
                   AlbumPrice = x.Price.ToString("f2")
                   
               })
               .OrderByDescending(x => decimal.Parse(x.AlbumPrice))
               .ToArray();

            var json = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new ExportSongDurationDTO
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers.Select(z => z.Performer.FirstName + " " + z.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToArray();

            var xml = XmlConverter.Serialize(songs, "Songs");

            return xml;
        }
    }
}