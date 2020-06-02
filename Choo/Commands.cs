using System.Windows.Input;

namespace Choo.Commands
{
    public class Commands
    {
        public static readonly RoutedUICommand ShowVideo = new RoutedUICommand
            (
                "Show video",
                "ShowVideo",
                typeof(Commands)
            );
    }
}