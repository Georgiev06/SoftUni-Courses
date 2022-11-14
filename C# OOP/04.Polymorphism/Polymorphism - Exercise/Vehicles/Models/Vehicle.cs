using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Interfaces
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapaciaty;


        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapaciaty)
        {
            this.TankCapaciaty = tankCapaciaty;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }

        public double TankCapaciaty
        {
            get => tankCapaciaty;
            private set
            {
                this.tankCapaciaty = value;
            }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > TankCapaciaty)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value;
            }
        }

        public double TankCapacity => throw new NotImplementedException();

        protected virtual double FuelConsumptionModifier { get; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionModifier;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual string DriveEmpty(double distance)
        {
            return "";
        }

        public virtual void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (fuelQuantity + amountOfFuel > tankCapaciaty)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }
            this.FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

