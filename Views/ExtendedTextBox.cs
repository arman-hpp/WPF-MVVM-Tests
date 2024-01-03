using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_MVVM_Tests.Views
{
    public class ExtendedTextBox : TextBox
    {
        public ExtendedTextBox()
        {
            PreviewKeyDown += ExtendedTextBox_PreviewKeyDown;
        }

        private void ExtendedTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key is Key.Enter or Key.Down)
            {
                MoveFocus(FocusNavigationDirection.Next);
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                MoveFocus(FocusNavigationDirection.Previous);
                e.Handled = true;
            }
        }

        private void MoveFocus(FocusNavigationDirection direction)
        {
            var request = new TraversalRequest(direction);
            if (Keyboard.FocusedElement is UIElement elementWithFocus)
                elementWithFocus.MoveFocus(request);
        }
    }
}
