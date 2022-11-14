using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption  => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower  { get; set; }

        public virtual void Drive(double kilometers)
        {
            if (this.Fuel - (kilometers * this.FuelConsumption) >= 0)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }
    }
}
