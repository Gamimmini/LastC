using System;

namespace Shape
{
  class Program
  {
    static void Main(string[] args)
    {
        Random random = new Random();
        Circle[] circles = new Circle[1];
        circles[0] = new Circle(2.0);
        for (int i = 0; i < circles.Length; i++)
        {
          Circle circle = circles[i];
          double originalArea = circle.GetArea();
          Console.WriteLine("Original circle Area " + originalArea);

          double resizePercent = random.Next(1, 101);
          circle.Resize(resizePercent);

          double resizedArea = circle.GetArea();
          Console.WriteLine("Resized circle Area " + resizedArea);
          Console.WriteLine();    
        }   
        Rectangle[] rectangles = new Rectangle[1];
        rectangles[0] = new Rectangle(2.0, 3.0);


        for (int i = 0; i < rectangles.Length; i++)
        {
          Rectangle rectangle = rectangles[i];

          double originalArea = rectangle.getArea();
          Console.WriteLine("Original rectangle Area " + originalArea);

          double resizePercent = random.Next(1, 101);
          rectangle.Resize(resizePercent);

          double resizedArea = rectangle.getArea();
          Console.WriteLine("Resized rectangle Area: " + resizedArea);
          Console.WriteLine();
        }

        Square[] squares = new Square[1];
        squares[0] = new Square(5.0);

        for (int i = 0; i < squares.Length; i++)
        {
          Square currentSquare = squares[i];

          double originalArea = currentSquare.getArea();
          Console.WriteLine("Original square Area: " + originalArea);

          double resizePercent = random.Next(1, 101);
          currentSquare.Resize(resizePercent);

          double resizedArea = currentSquare.getArea();
          Console.WriteLine("Resized square Area: " + resizedArea);
          Console.WriteLine();
        }
        Shape[] shapes = new Shape[3];
        shapes[0] = new Circle(3.5);
        shapes[1] = new Rectangle(2.0, 3.0);
        shapes[2] = new Square(5.8);

        foreach (Shape shape in shapes)
        {
          Console.WriteLine(shape);

          if (shape is IColorable colorableShape)
          {
            colorableShape.HowToColor();
          }
            Console.WriteLine();
        }
    }
  }
}