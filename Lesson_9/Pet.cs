using System.Timers;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Timer = System.Timers.Timer;

namespace Lesson_9
{
    internal class Pet : IRequest
    {
        int countCancel;
        public string Name { get; }
        public int ProgramTime { get; }
        Timer aTimer;
        Random random;
        List<string> request;
        string tmpRequest;
        int consoleCursorTop;

        public Pet(string name, int time)
        {
            Name = name;
            ProgramTime = time;
            countCancel = 0;
            random = new Random();
            tmpRequest = string.Empty;
            consoleCursorTop = 7;
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

        public void Kick() => Environment.Exit(0);

        public string Play() => "Хочу играть. Сыграем?";

        public string Sleep() => "Хочу спать. Дай подушку";

        public string Treat() => "Я заболел. Дай таблетку";

        public string Walk() => "Хочу гулять. Пойдем?";

        public void TimeIsOver()
        {
            Console.WriteLine("Время вышло");
            Environment.Exit(0);
        }

        void SetTimer()
        {
            aTimer = new Timer(random.Next(10000, 20000));
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        void SetTimerStartStop()
        {
            aTimer = new Timer(ProgramTime);
            aTimer.Elapsed += StartStop;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        void StartStop(Object obj, ElapsedEventArgs e)
        {
            TimeIsOver();
        }

        void OnTimedEvent(Object obj, ElapsedEventArgs e)
        {
            int numberRequest;
            do
            {
                numberRequest = random.Next(0, request.Count);
            } while (tmpRequest == request[numberRequest]);
            tmpRequest = request[numberRequest];

            if (Say(tmpRequest) == DialogResult.OK)
            {
                Show();
                ConsoleCursor();
                Console.WriteLine($"{e.SignalTime} - OK");
            }
            else
            {
                countCancel++;
                Show();
                ConsoleCursor();
                Console.WriteLine($"{e.SignalTime} - Cancel");
                if (countCancel == 3)
                {
                    if (Say(Treat()) == DialogResult.OK)
                    {
                        countCancel = 0;
                        Show();
                        ConsoleCursor();
                        Console.WriteLine($"{e.SignalTime} - OK");
                    }
                    else
                    {
                        countCancel++;
                        Show();
                        ConsoleCursor();
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
                Show();
                SetTimer();
                SetTimerStartStop();
                Console.ReadLine();
                aTimer.Stop();
                aTimer.Dispose();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        void Face()
        {
            Console.WriteLine("\t    ^^^");
            Console.WriteLine("\t   @@@@@");
            Console.WriteLine("\t  @     @");
            Console.WriteLine("\t$@  O O  @$");
            Console.WriteLine("\t$@   |   @$");
            Console.WriteLine("\t @   -   @");
            Console.WriteLine("\t  @_____@");
        }

        void ConsoleCursor()
        {
            Console.CursorTop = consoleCursorTop++;
        }

        public void Show()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            switch (countCancel)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                default:
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Face();
            Console.ResetColor();
        }
    }
}
