using System;

namespace QuadLibrary
{
    public class Quad
    {
        private double width = 0.0;
        private double height = 0.0;
        public Quad(double w, double h)
        {
            width = w;
            height = h;
        }
        public double GetQuadArea()
        {
            return width * height;
        }
    }
}
