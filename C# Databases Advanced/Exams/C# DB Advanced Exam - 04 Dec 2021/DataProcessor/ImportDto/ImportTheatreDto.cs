using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 10)]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [JsonProperty("Director")]
        public string Director { get; set; } = null!;

        [Required]
        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; } = null!;
    }
}
