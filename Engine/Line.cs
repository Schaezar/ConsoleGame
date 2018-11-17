using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Line
    {
        public string Content { get; set; }
        public ConsoleColor Color { get; set; }

        public Line(string content, ConsoleColor color)
        {
            Content = content;
            Color = color;
        }
    }
}
