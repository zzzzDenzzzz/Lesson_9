using System;
using System.Collections.Generic;

namespace Lesson_9
{
    internal class TamagochiArgs
    {
        string title;
        string text;
        int icon;
        static TamagochiArgs prevTamagochiArgs = null;
        static List<string> args = new List<string>()
        {
            "Хочу есть",
            "Хочу спать",
            "Я заболел",
            "Поиграй со мной",
            "Давай погуляем"
        };

        TamagochiArgs(string title, string text, int icon)
        {
            this.title = title;
            this.text = text;
            this.icon = icon;
        }

        public static TamagochiArgs getMessageArgs()
        {
            TamagochiArgs tamagochiArgs = null;
            Random random = new Random();
            int i = random.Next(0, 4);
            switch (i)
            {
                case 0:
                    icon =
                    break;
                default:
                    break;
            }

            new TamagochiArgs("Тамагочи", args[i], )
        }
    }
}
