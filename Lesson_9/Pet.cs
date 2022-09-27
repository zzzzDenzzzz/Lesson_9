using System.Timers;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Lesson_9
{
    internal class Pet : IRequest
    {
        int countCancel;
        public string Name { get; }
        System.Timers.Timer aTimer;
        Random random;
        List<string> request;

        public Pet(string name)
        {
            Name = name;
            countCancel = 0;
            random = new Random();
            request = new List<string>()
            {
                Eat(),
                Play(),
                Sleep(),
                Walk()
            };
        }

        public DialogResult Say(string message = "Привет! Давай поиграем?")
        {
            return MessageBox.Show(message, Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0);
        }

        public string Eat() => "Хочу есть. Покормишь меня?";

        public void Kick()
        {
            Environment.Exit(0);
        }

        public string Play() => "Хочу играть. Сыграем?";

        public string Sleep() => "Хочу спать. Дай подушку";

        public string Treat() => "Я заболел. Дай таблетку";

        public string Walk() => "Хочу гулять. Пойдем?";

        void SetTimer()
        {
            aTimer = new System.Timers.Timer(random.Next(10000, 20000));
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        void TimeManagement()
        {
            SetTimer();
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
        }

        void OnTimedEvent(Object obj, ElapsedEventArgs e)
        {
            if (Say(request[random.Next(0, request.Count)]) == DialogResult.OK)
            {
                Console.WriteLine($"{e.SignalTime} - OK");
            }
            else
            {
                countCancel++;
                Console.WriteLine($"{e.SignalTime} - Cancel");
                if (countCancel == 3)
                {
                    if (Say(Treat()) == DialogResult.OK)
                    {
                        Console.WriteLine($"{e.SignalTime} - OK");
                        countCancel = 0;
                    }
                    else
                    {
                        Console.WriteLine($"{e.SignalTime} - {Name} R.I.P");
                        Kick();
                    }
                }
            }
        }

        public void Game()
        {
            if (Say() == DialogResult.OK)
            {
                TimeManagement();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
