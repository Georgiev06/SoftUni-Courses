using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        { 
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get 
            { 
                return this.length; 
            }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value; 
            }
        }
        public double Width
        {
            get 
            { 
                return this.width; 
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value; 
            }
        }
        public double Height
        {
            get 
            { 
                return this.height; 
            }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value; 
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = 0;
            surfaceArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return surfaceArea;
        }
        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 0;
            lateralSurfaceArea = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = 0;
            volume = this.Length * this.Width * this.Height;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }

    }
}
