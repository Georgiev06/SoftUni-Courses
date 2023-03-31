using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Artillery.Data.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new List<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }

        [Required] 
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [Required] 
        public int GunWeight { get; set; }

        [Required] 
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [ForeignKey(nameof(Shell))]
        public int ShellId { get; set; }

        [Required] 
        public virtual Shell Shell { get; set; } = null!;

        [Required]
        public virtual ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
