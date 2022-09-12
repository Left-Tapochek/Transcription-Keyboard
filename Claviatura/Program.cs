using Keyboard.Model;
using Keyboard.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main_form mainForm = new Main_form();
            KeyboardBL keyboardBL = new KeyboardBL();
            MessageServise messageServise = new MessageServise();

            MainPresenter mainPresenter = new MainPresenter(mainForm, keyboardBL, messageServise);

            Application.Run(mainForm);
        }
    }
}
