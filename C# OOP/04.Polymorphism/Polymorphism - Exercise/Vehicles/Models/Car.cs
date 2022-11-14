using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarFuelConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapaciaty)
            : base(fuelQuantity, fuelConsumption, tankCapaciaty)
        {

        }

        protected override double FuelConsumptionModifier => base.FuelConsumption + CarFuelConsumption;
    }
}
