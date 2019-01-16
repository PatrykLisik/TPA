using System.Threading.Tasks;
using ViewModel;

namespace TUI2
{
    public class MainClass
    {

        public static async Task MainAsync(string[] args)
        {
            TextView view = new TextView();
            await view.RunAsync();
        }

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

    }
}
