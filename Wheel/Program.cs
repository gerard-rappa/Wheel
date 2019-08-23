using System;
using System.Runtime.InteropServices;

namespace Roulette
{
    static class Imports
    {
        public static IntPtr HWND_BOTTOM = (IntPtr)1;
        // public static IntPtr HWND_NOTOPMOST = (IntPtr)-2;
        public static IntPtr HWND_TOP = (IntPtr)0;
        // public static IntPtr HWND_TOPMOST = (IntPtr)-1;

        public static uint SWP_NOSIZE = 1;
        public static uint SWP_NOZORDER = 4;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(45, 20);
            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);

            int i = int.Parse(args[0]);//takes input from args for wheel number
            int spin = 0;//number increments (spin) times in whie loop
            int speed = 300;
            Console.ForegroundColor = ConsoleColor.White;
            while (spin <= 38*15)//how many times wheel spins (38*1) = 1 rotation
            {
                Console.Clear();
                Number x = new Number(i);
                Console.WriteLine();
                Console.BackgroundColor = x.background;
                Console.WriteLine(x.representation);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                // USE THESE IF STATEMENTS TO MAKE SMOOTH SLOWDOWN and make wheel spin for about 10 seconds
                if (spin < 100) speed = 4;
                if (spin >= 100 && spin < 400) speed = 40;
                if (spin >= 400 && spin < 470) speed = 95;
                if (spin >= 470 && spin < 550) speed = 195;
                if (spin >= 550 && spin < 565) speed = 300;
                if (spin >= 565 && spin < 568) speed = 450;
                if (spin >= 569 && spin < 570) speed = 550;
                spin++;

                System.Threading.Thread.Sleep(speed);
                if (i < 37) i++;
                else i = 0;
            }
            while (true)
            {
                Console.Write("");
            }
        }
    }
}