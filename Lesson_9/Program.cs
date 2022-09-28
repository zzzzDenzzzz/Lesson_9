using System.Threading;

namespace Lesson_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pet = new Pet("Face", 60000);
            var pet1 = new Pet("Ecaf", 80000);

            var thread = new Thread(pet.Game);
            var thread1 = new Thread(pet1.Game);

            thread.Start();
            thread1.Start();
        }
    }
}
