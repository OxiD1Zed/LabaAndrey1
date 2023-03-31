using System;
using System.Diagnostics;
using System.Linq;

namespace _1лабаАндрей
{
    public class Triangle
    {
        public double[] Sides
        {
            get
            {
                return _sides;
            }
            set
            {
                for (int i = 0; i < 3; i++)
                {
                    if (value[i] <= 0)
                        throw new ArgumentException("Сторона не может быть меньше или равна нулю");
                }

                Array.Sort(value);
                if (value[0] + value[1] <= value[2])
                    throw new ArithmeticException("Сумма двух сторон меньше или равна третьей");

                _sides = value;
            }
        }
        public double Area { get; private set; }
        public double Perimetr { get; private set; }
        public Triangles[] Types { get; private set; }

        private double[] _sides;

        public Triangle(double a, double b, double c)
        {
            Sides = new double[] {  a, b, c };
            Area = GetArea();
            Perimetr = GetPerimetr();
            Types = GetTypesTriangle();
        }

        private Triangles[] GetTypesTriangle()
        {
            return new Triangles[] { GetTypeTriangleSide(), GetTypeTriangleAngle() };
        }
        private Triangles GetTypeTriangleSide()
        {
            if (Sides[0] == Sides[1] || Sides[1] == Sides[2])
            {
                if (Sides[0] == Sides[2])
                {
                    return Triangles.Equilateral;
                }
                else
                {
                    return Triangles.Isosceles;
                }
            }

            return Triangles.Scalene;
        }
        private Triangles GetTypeTriangleAngle()
        {
            if (Math.Pow(Sides[0], 2) + Math.Pow(Sides[1], 2) == Math.Pow(Sides[2], 2))
                return Triangles.Rectangular;
            else if (Math.Pow(Sides[0], 2) + Math.Pow(Sides[1], 2) > Math.Pow(Sides[2], 2))
                return Triangles.Sharp;

            return Triangles.Obtuse;
        }
        private double GetArea()
        {
            double halfPerimetr = GetPerimetr() / 2;
            return Math.Round(Math.Sqrt(halfPerimetr * (halfPerimetr - Sides[0])
                                          * (halfPerimetr - Sides[1])
                                          * (halfPerimetr - Sides[2])), 6);
        }
        private double GetPerimetr()
        {
            return Sides[0] + Sides[1] + Sides[2];
        }

        public bool Equals(Triangle triangle)
        {
            bool result = true;

            for (int i = 0; i < 3; i++)
            {
                if (Sides[i] != triangle.Sides[i])
                    result = false;
            }

            return result;
        }
        public override string ToString()
        {
            return base.ToString().Remove(0, base.ToString().IndexOf('.') + 1) + $"\nSide_1: {_sides[0]}\nSide_2: {_sides[1]}\nSide_3: {_sides[2]}\nTypes: {Types[0].ToString()}, {Types[1].ToString()}\nArea: {Area}\nPerimetr: {Perimetr}";
        }
    }


    public enum Triangles
    {
        Isosceles,
        Equilateral,
        Scalene,
        Rectangular,
        Sharp,
        Obtuse
    }
}
