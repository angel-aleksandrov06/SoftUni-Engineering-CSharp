using System;
using System.Collections.Generic;
using System.Text;

namespace _01ClassBoxData
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
                if (IsValid(value))
                {
                    this.length = value;
                }
                else
                {
                    throw new Exception($"Length cannot be zero or negative.");
                }
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
                if (IsValid(value))
                {
                    this.width = value;
                }
                else
                {
                    throw new Exception($"Width cannot be zero or negative.");
                }
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
                if (IsValid(value))
                {
                    this.height = value;
                }
                else
                {
                    throw new Exception($"Height cannot be zero or negative.");
                }
            }
        }

        private bool IsValid(double number)
        {
            if (number > 0)
            {
                return true;
            }
            return false;
        }

        public double GetBoxSurfaceArea()
        {
            var result = 2 * (this.Length * this.Width) + 
                         2 * (this.Length * this.Height) + 
                         2 * (this.Width * this.Height);

            return result;
        }

        public double GetBoxLateralSurfaceArea()
        {
            var result = 2 * (this.Length * this.Height) + 
                         2 * (this.Width * this.Height);

            return result;
        }

        public double GetBoxVolume()
        {
            var result = this.Length * this.Width * this.Height;

            return result;
        }
    }
}
