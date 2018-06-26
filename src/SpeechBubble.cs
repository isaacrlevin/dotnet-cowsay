using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnetcowsay
{
    static public class SpeechBubble
    {
        static public string ReturnSpeechBubble(string message, IBubbleChars bubbles, int maxLineLength)
        {
            char[] splitChar = { ' ', (char)10, (char)13 };
            List<string> messageAsList = new List<string>();

            messageAsList = message.Split(
                                            new[] { "\r\n", "\r", "\n" },
                                            StringSplitOptions.None
                                         ).ToList();


            if (message.Length > maxLineLength || messageAsList.Count > 1)
            {
                message = CreateLargeWordBubble(messageAsList, bubbles);
            }
            else
            {
                message = CreateSmallWordBubble(message, bubbles);
            }

            return message;
        }

        static string RepeatCharacter(char character, int numberOfUnderscores)
        {
            return new string(character, numberOfUnderscores);
        }

        static string CreateSmallWordBubble(string message, IBubbleChars bubbles)
        {
            int lengthOfMessage = message.Length;
            int lengthOfTopAndBottomLinesInBubble = lengthOfMessage + 2;
            string topBubbleLine = RepeatCharacter(bubbles.TopLine, lengthOfTopAndBottomLinesInBubble);
            string bottomBubbleLine = RepeatCharacter(bubbles.BottomLine, lengthOfTopAndBottomLinesInBubble);

            return $" {topBubbleLine} \r\n{bubbles.SmallLeft} {message.Trim()} {bubbles.SmallRight}\r\n {bottomBubbleLine}";
        }

        static string CreateLargeWordBubble(List<string> list, IBubbleChars bubbles)
        {
            StringBuilder bubbleBuilder = new StringBuilder();
            int longestLineInList = list.Max(s => s.Length);
            int lengthOfTopAndBottomLinesInBubble = longestLineInList + 2;
            string topBubbleLine = $" {RepeatCharacter(bubbles.TopLine, lengthOfTopAndBottomLinesInBubble)}";
            string bottomBubbleLine = $" {RepeatCharacter(bubbles.BottomLine, lengthOfTopAndBottomLinesInBubble)}";
            string firstLineInMessageSpaces = RepeatCharacter(' ', longestLineInList - list[0].Length + 1);
            string lastLineInMessageSpaces = RepeatCharacter(' ', longestLineInList - list[list.Count - 1].Length + 1);

            bubbleBuilder.AppendLine(topBubbleLine);
            bubbleBuilder.AppendLine($"{bubbles.UpLeft} {list[0]}{firstLineInMessageSpaces}{bubbles.UpRight}");
            for (int i = 1; i < list.Count() - 1; i++)
            {
                int numberofspaces = longestLineInList - list[i].Length;
                string spacesInLine = RepeatCharacter(' ', numberofspaces + 1);

                bubbleBuilder.AppendLine($"{bubbles.Left} {list[i]}{spacesInLine}{bubbles.Right}");
            }
            bubbleBuilder.AppendLine($"{bubbles.DownLeft} {list[list.Count - 1]}{lastLineInMessageSpaces}{bubbles.DownRight}");
            bubbleBuilder.AppendLine(bottomBubbleLine);

            return bubbleBuilder.ToString();
        }
    }
}
