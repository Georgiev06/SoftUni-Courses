using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;
using Trucks.Utilities;

namespace Theatre.DataProcessor
{

    using System;
    using Theatre.Data;
    using Theatre.Data.Models;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t => t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets
                        .Where(t => t.RowNumber <= 5)
                        .Select(t => new
                        {
                            Price = t.Price,
                            RowNumber = t.RowNumber
                        })
                        .ToArray()
                        .OrderByDescending(t => t.Price)
                })
                .ToArray()
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name);

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var plays = context.Plays
                .Where(p => p.Rating <= raiting)
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(a => new ExportActorDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize(plays, "Plays");
        }
    }
}
