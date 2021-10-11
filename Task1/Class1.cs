using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Triangle
    {
        public readonly double[] sides;
        public Triangle()
        {
            sides = new double[3];
        }
        private bool IsGoodSideVal(int sideIndex, double val)
        {
            if (val > 0)
            {
                switch (sideIndex)
                {
                    case 0:
                        if (sides[1] + sides[2] > val && sides[1] + val > sides[2] && sides[2] + val > sides[1])
                        {
                            return true;
                        }
                        break;
                    case 1:
                        if (sides[0] + sides[2] > val && sides[0] + val > sides[2] && sides[2] + val > sides[0])
                        {
                            return true;
                        }
                        break;
                    case 2:
                        if (sides[0] + sides[1] > val && sides[1] + val > sides[0] && sides[0] + val > sides[1])
                        {
                            return true;
                        }
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
        public virtual bool ChangeSide(double val, int sideIndex)
        {
            if (sides[sideIndex] == 0 || IsGoodSideVal(sideIndex,val))
            {
                sides[sideIndex] = val;
                return true;
            }
            return false;
        }
        public virtual double[] GetAngles()
        {
            double[] angles = new double[3];
            angles[0] = Math.Acos((Math.Pow(sides[0], 2) + Math.Pow(sides[2], 2) - Math.Pow(sides[1], 2)) 
                / (2 * sides[0] * sides[2])) * 180 / Math.PI;
            //angle between sides 0 and 2
            angles[1] = Math.Acos((Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) 
                / (2 * sides[0] * sides[1])) * 180 / Math.PI;
            //angle between sides 0 and 1
            angles[2] = 180 - angles[0] - angles[1];
            return angles;
        }

        public double GetPerimeter()
        {
            return sides[0] + sides[1] + sides[2];
        }
    }

    public class EquilateralTriangle:Triangle
    {
        public EquilateralTriangle() : base() { }

        public override bool ChangeSide(double val, int sideIndex = 0)
        {
            if(val > 0)
            {
                for(int i=0;i<3;i++)
                {
                    sides[i] = val;
                }
                return true;
            }
            return false;
        }

        public override double[] GetAngles()
        {
            return new double[] { 60, 60, 60 };
        }
        public double GetSquare()
        {
            return (Math.Sqrt(3) / 4) * sides[0];
        }
    }
}
