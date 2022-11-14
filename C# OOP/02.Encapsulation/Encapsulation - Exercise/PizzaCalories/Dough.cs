using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private double bakingModifier;
        private double flourModifier;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
            this.FlourModifier = flourModifier;
            this.BakingModifier = bakingModifier;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if ((string.IsNullOrEmpty(value)) || (value.ToLower() != "white" && value.ToLower() != "wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if ((string.IsNullOrEmpty(value)) || (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")) 
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.grams = value;
            }
        }

        public double FlourModifier
        {
            get
            {
                return this.flourModifier;
            }
            private set
            {
                if (this.FlourType.ToLower() == "white")
                {
                    this.flourModifier = 1.5;
                }
                else if (this.FlourType.ToLower() == "wholegrain")
                {
                    this.flourModifier = 1.0;
                }
            }
        }

        public double BakingModifier
        {
            get 
            { 
                return this.bakingModifier; 
            }
            private set 
            {
                if (this.bakingTechnique.ToLower() == "crispy")
                {
                    this.bakingModifier = 0.9;
                }
                else if (this.bakingTechnique.ToLower() == "chewy")
                {
                    this.bakingModifier = 1.1;
                }
                else if (this.bakingTechnique.ToLower() == "homemade")
                {
                    this.bakingModifier = 1.0;
                }
            }
        }
        public double CalculateCalories() => (2 * this.Grams) * this.FlourModifier * this.BakingModifier;
    }
}
