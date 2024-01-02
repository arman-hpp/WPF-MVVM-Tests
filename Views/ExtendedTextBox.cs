using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (e.Key == Key.Enter)
            {
                // Move focus to the next control in the tab order
                var request = new TraversalRequest(FocusNavigationDirection.Next);
                var elementWithFocus = Keyboard.FocusedElement as UIElement;

                if (elementWithFocus != null)
                {
                    elementWithFocus.MoveFocus(request);
                }

                // Mark the event as handled to prevent further processing
                e.Handled = true;
            }
        }
    }
}
