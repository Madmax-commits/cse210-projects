using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual shapes
        Square square = new Square("Red", 4);
        Console.WriteLine($"Square Color: {square.GetColor()}");
        Console.WriteLine($"Square Area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Blue", 5, 3);
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}");
        Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");

        Circle circle = new Circle("Green", 2.5);
        Console.WriteLine($"Circle Color: {circle.GetColor()}");
        Console.WriteLine($"Circle Area: {circle.GetArea()}");

        Console.WriteLine("\n--- Polymorphism with List ---");

        // Create list of shapes
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Yellow", 6));
        shapes.Add(new Rectangle("Purple", 4, 7));
        shapes.Add(new Circle("Orange", 3));

        // Iterate and display
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
