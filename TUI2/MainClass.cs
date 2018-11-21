using ViewModel;

namespace TUI2
{
    public class MainClass
    {

        static void Main(string[] args)
        {
            TextView view = new TextView(new ConsolePathGeter());
            view.Run();
        }


    }
}
