using P02.Graphic_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Graphic_Editor
{
    public class Triangle : IShape
    {
        public string Draw()
        {
            return "I'm Triangle";
        }
    }
}
