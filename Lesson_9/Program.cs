using System;
using System.Windows.Forms;
using System.Timers;

namespace Lesson_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pet = new Pet("Toy");

            pet.Game();
        }
    }
}
