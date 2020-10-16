namespace Springboard365.Tools.DynamicsCrm.ExportCustomizations
{
    using System;

    public static class ProgressBar
    {
        public static void DrawProgressBar(int progress, int total, string currentStageName)
        {
            var dateTimeString = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss  ");
            var positionStart = 0 + dateTimeString.Length;
            var positionEnd = 32 + dateTimeString.Length;

            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write(dateTimeString + "["); //start
            Console.CursorLeft = positionEnd;
            Console.Write("]"); //end
            Console.CursorLeft = positionStart + 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = positionStart + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= positionEnd - 1; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = positionEnd + 3;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "  -  "); //blanks at the end remove any excess
            Console.WriteLine(currentStageName);
        }
    }
}