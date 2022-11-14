using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumption = 1.6;
        private const double RefuelCoeffiecient = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapaciaty)
            : base(fuelQuantity, fuelConsumption, tankCapaciaty)
        {

        }

        protected override double FuelConsumptionModifier => base.FuelConsumption + TruckFuelConsumption;

        public override void Refuel(double amountOfFuel)
        {

            base.Refuel(amountOfFuel);
            FuelQuantity -= amountOfFuel * RefuelCoeffiecient;
        }
    }
}
