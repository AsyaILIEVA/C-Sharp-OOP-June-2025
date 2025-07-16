using P02.Graphic_Editor.Interfaces;
using System;
using System.Threading.Channels;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            var result = shape.Draw();

            Console.WriteLine(result);
        }
        
    }
}
