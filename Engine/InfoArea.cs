using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InfoArea
    {
        public List<Line> Buffer = new List<Line>();

        public int MinLine { get; }
        public int MaxLine { get; }
        public int LeftMargin { get; }
        public int MaxBufferLength { get; }
        public int CurrConsoleLine { get; set; }

        public InfoArea(int minLine, int maxLine, int leftMargin, int maxBufferLength, int currConsoleLine)
        {
            MinLine = minLine;
            MaxLine = maxLine;
            LeftMargin = leftMargin;
            MaxBufferLength = maxBufferLength;
            CurrConsoleLine = currConsoleLine;
        }

        public void ClearBox()
        {
            for (int i = MinLine; i <= MaxLine; i++)
            {
                Console.SetCursorPosition(LeftMargin, i + 1);
                UI.FillLine(' ');
            }
        }
    }
}
