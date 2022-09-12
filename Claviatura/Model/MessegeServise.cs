using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard.Model
{
    public interface IMassageServise
    {
        void ShowMessege(string text);
        void ShowExclamation(string exclamation);
        void showError(string error);
    }
    internal class MessageServise : IMassageServise
    {
        public void showError(string error)
        {
            MessageBox.Show(error, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowMessege(string text)
        {
            MessageBox.Show(text, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
