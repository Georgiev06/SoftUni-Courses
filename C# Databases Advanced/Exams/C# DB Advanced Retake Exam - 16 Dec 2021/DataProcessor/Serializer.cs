
using Artillery.DataProcessor.ExportDto;
using Newtonsoft.Json;
using Trucks.Utilities;

namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => ((int)g.GunType) == 3)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .ToArray()
                        .OrderByDescending(g => g.GunWeight)
                })
                .ToArray()
                .OrderBy(s => s.ShellWeight);

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var guns = context.Guns.Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new ExportGunDto
                {
                    ManufacturerName = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    BarrelLength = x.BarrelLength,
                    GunWeight = x.GunWeight,
                    Range = x.Range,
                    Countries = x.CountriesGuns.Where(x => x.Country.ArmySize > 4500000)
                        .Select(a => new ExportCountryDto
                        {
                            CountryName = a.Country.CountryName,
                            ArmySize = a.Country.ArmySize
                        })
                        .OrderBy(x => x.ArmySize)
                        .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            return xmlHelper.Serialize(guns, "Guns");
        }
    }
}
