using System;

public class TREUGOLNIK
{
    private double Ax, Ay, Bx, By, Cx, Cy;

    public TREUGOLNIK(double ax, double ay, double bx, double by, double cx, double cy)
    {
        Ax = ax;
        Ay = ay;
        Bx = bx;
        By = by;
        Cx = cx;
        Cy = cy;
    }

    public bool IsTriangle()
    {
        double area = 0.5 * Math.Abs(Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By));
        return area > 0;
    }

    public double Perimeter()
    {
        double sideAB = Distance(Ax, Ay, Bx, By);
        double sideBC = Distance(Bx, By, Cx, Cy);
        double sideCA = Distance(Cx, Cy, Ax, Ay);
        return sideAB + sideBC + sideCA;
    }

    public double Area()
    {
        double sideAB = Distance(Ax, Ay, Bx, By);
        double sideBC = Distance(Bx, By, Cx, Cy);
        double sideCA = Distance(Cx, Cy, Ax, Ay);
        double s = (sideAB + sideBC + sideCA) / 2;
        return Math.Sqrt(s * (s - sideAB) * (s - sideBC) * (s - sideCA));
    }

    private double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}

public class Program
{
    public static void Main()
    {
        TREUGOLNIK triangle = new TREUGOLNIK(1, 6, 3, 2, 0, 4);

        if (triangle.IsTriangle())
        {
            Console.WriteLine("Можно построить треугольник с заданными точками.");
            Console.WriteLine($"Периметр треугольника: {triangle.Perimeter()}");
            Console.WriteLine($"Площадь треугольника: {triangle.Area()}");
        }
        else
        {
            Console.WriteLine("Невозможно построить треугольник с заданными точками.");
        }
    }
}
