using System;

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class TREUGOLNIK
{
    protected Point A, B, C;

    public TREUGOLNIK(Point a, Point b, Point c)
    {
        A = a;
        B = b;
        C = c;
    }

    protected double Distance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
    }

    public bool CanFormTriangle()
    {
        double AB = Distance(A, B);
        double BC = Distance(B, C);
        double CA = Distance(C, A);

        //Проверяем неравенство треугольника
                 return AB + BC > CA && AB + CA > BC && BC + CA > AB;
    }
}

public class VICHISLI : TREUGOLNIK
{
    public VICHISLI(Point a, Point b, Point c) : base(a, b, c) { }

    public double Median()
    {
        double AB = Distance(A, B);
        double BC = Distance(B, C);
        double CA = Distance(C, A);

        //Вычисляем медиану
                 return 0.5 * Math.Sqrt(2 * BC * BC + 2 * CA * CA - AB * AB);
    }

    public double Height()
    {
        double AB = Distance(A, B);
        double BC = Distance(B, C);
        double CA = Distance(C, A);

        //Вычисляем высоту
                 double p = (AB + BC + CA) / 2;
        return 2 * Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA)) / AB;
    }

    public double Bisector()
    {
        double AB = Distance(A, B);
        double BC = Distance(B, C);
        double CA = Distance(C, A);

        //Вычисляем биссектрису
                 return Math.Sqrt(BC * CA * (BC + CA) / (BC + CA)) - AB;
    }

    public double Inradius()
    {
        double AB = Distance(A, B);
        double BC = Distance(B, C);
        double CA = Distance(C, A);

        //Вычисляем радиус вписанной окружности
                 double p = (AB + BC + CA) / 2;
        return Math.Sqrt((p - AB) * (p - BC) * (p - CA) / p);
    }

    public double Circumradius()
    {
        double AB = Distance(A, B);
        double BC = Distance(B, C);
        double CA = Distance(C, A);

        //Вычисляем радиус описанной окружности
                 return AB * BC * CA / (4 * Math.Sqrt((AB + BC + CA) * (BC + CA - AB) * (CA + AB - BC) * (AB + BC - CA)));
    }
}

class Program
{
    static void Main()
    {
        //Создаем новые точки
       Point A = new Point(0, 0);
        Point B = new Point(0, 1);
        Point C = new Point(1, 0);

        //Создаем новый объект класса VICHISLI
       VICHISLI triangle = new VICHISLI(A, B, C);

        //Вычисляем и выводим медиану, высоту, биссектрису, радиус вписанной и описанной окружностей
                 Console.WriteLine("Медиана: " + triangle.Median());
        Console.WriteLine("Высота: " + triangle.Height());
        Console.WriteLine("Биссектриса: " + triangle.Bisector());
        Console.WriteLine("Радиус вписанной окружности: " + triangle.Inradius());
        Console.WriteLine("Радиус описанной окружности: " + triangle.Circumradius());
    }
}