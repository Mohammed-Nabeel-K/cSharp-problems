using System;

namespace projectday3
{
    interface IShape
    {
        public double getArea();
  
    }
    class Circle : IShape
    {
        double Radius { get; set; }
        public Circle(double radius) { 
            Radius = radius;
        }
        public double getArea()
        {
            return 3.14 * Radius * Radius;
        }
    }
    class Rectangle : IShape
    {
        double Height { get; set; }
        double Width { get; set; }
        public Rectangle(double height,double width)
        {
            Height = height;
            Width = width;
        }
        public double getArea()
        {
            return Height * Width;
        }
    }
    class Square : IShape 
    {
        double Height { get; set; }
        public Square(double height)
        {
            Height = height;
        }
        public double getArea()
        {
            return  Height * Height;
        }
    }
    class starter
    {
        public static void Main(String[] args)
        {
            IShape circle = new Circle(10);
            IShape rectangle = new Rectangle(5, 8);
            IShape square = new Square(13);
            Console.WriteLine($"Area of Circle : {circle.getArea()}");
            Console.WriteLine($"Area of Rectangle : {rectangle.getArea()}");
            Console.WriteLine($"Area of Square : {square.getArea()}");
            int x = Console.Read();
        }
    }
}