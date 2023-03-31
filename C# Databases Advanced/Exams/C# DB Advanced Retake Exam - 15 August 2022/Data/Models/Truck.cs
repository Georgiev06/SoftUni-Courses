using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key] //--> System.ComponentModel.DataAnnotations
        public int Id { get; set; }

        [MaxLength(8)] 
        public string RegistrationNumber { get; set; }

        [Required] 
        [MaxLength(17)] 
        public string VinNumber { get; set; } = null!;

        public int TankCapacity  { get; set; }

        public int CargoCapacity { get; set; }

        public CategoryType CategoryType { get; set; } //--> Enum is required by default!!!

        public MakeType MakeType { get; set; }

        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }

        public virtual Despatcher Despatcher { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
