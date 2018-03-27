using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graph = new GraphicEditor();

            graph.DrawShape(new Rectangle());
            graph.DrawShape(new Circle());
            graph.DrawShape(new Square());
        }
    }
}
