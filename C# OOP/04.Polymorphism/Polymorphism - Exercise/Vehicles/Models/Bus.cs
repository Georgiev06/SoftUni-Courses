using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionFull = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapaciaty)
            : base(fuelQuantity, fuelConsumption, tankCapaciaty)
        {

        }
        protected override double FuelConsumptionModifier => base.FuelConsumption + BusFuelConsumptionFull;

        public override void Refuel(double amountOfFuel)
        {
            base.Refuel(amountOfFuel);
        }

        public override string DriveEmpty(double distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

    }
}

