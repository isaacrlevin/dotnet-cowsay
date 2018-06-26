using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetcowsay
{
    public class SayBubbleChars : BubbleChars
    {
        public SayBubbleChars()
        {
            UpLeft = DownRight = "/";
            UpRight = DownLeft = Bubble = "\\";
            Left = Right = "|";
            SmallLeft = "<";
            SmallRight = ">";
        }
    }
}
