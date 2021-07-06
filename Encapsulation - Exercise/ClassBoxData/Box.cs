using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght 
        {
            get => this.lenght;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }

                this.lenght = value;
            }
        }

        public double Width 
        {
            get => this.width;
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
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double FindSurfaceArea()
        {
            double result = 2.0 * this.Lenght * this.Width + 2.0 * this.Lenght * this.Height
                + 2.0 * this.Width * this.Height;

            return result;
        }

        public double FindLateralSurfaceArea()
        {
            double result = 2.0 * this.Lenght * this.Height + 2.0 * this.Width * this.Height;

            return result;
        }

        public double FindVolume()
        {
            double result = this.Lenght * this.Width * this.Height;

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.FindSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.FindLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.FindVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
