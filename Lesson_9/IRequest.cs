using System.Windows.Forms;

namespace Lesson_9
{
    internal interface IRequest
    {
        // есть
        string Eat();
        // гулять
        string Walk();
        // спать
        string Sleep();
        // лечить
        string Treat();
        // играть
        string Play();
        // умереть
        void Kick();
        // говорить
        DialogResult Say(string message = "Привет! Давай поиграем?");

        void Show();

        void TimeIsOver();
    }
}
