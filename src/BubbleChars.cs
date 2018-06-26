using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetcowsay
{
    public interface IBubbleChars
    {
        char TopLine { get; }
        char BottomLine { get; }
        string UpLeft { get; }
        string UpRight { get; }
        string DownLeft { get; }
        string DownRight { get; }
        string Left { get; }
        string Right { get; }
        string SmallLeft { get; }
        string SmallRight { get; }
        string Bubble { get; }
    }

    public class BubbleChars : IBubbleChars
    {
        public char TopLine { get; set; }
        public char BottomLine { get; set; }
        public string UpLeft { get; set; }
        public string UpRight { get; set; }
        public string DownLeft { get; set; }
        public string DownRight { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string SmallLeft { get; set; }
        public string SmallRight { get; set; }
        public string Bubble { get; set; }

        public BubbleChars()
        {
            TopLine = '_';
            BottomLine = '-';
        }
    }
}
