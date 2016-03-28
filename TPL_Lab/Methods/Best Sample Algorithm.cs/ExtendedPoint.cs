using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL_Lab.Methods.Best_Sample_Algorithm.cs
{
    public struct ExtendedPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }
        public double ValueFunction { get; set; }

        /// <summary>
        /// Initialization params ExtendedPoint
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="valueFunction"></param>
        /// <param name="angle"></param>
        public ExtendedPoint(double x, double y, double valueFunction, double angle)
        {
            this.X = x;
            this.Y = y;
            this.ValueFunction = valueFunction;
            this.Angle = angle;
        }
    }
}
