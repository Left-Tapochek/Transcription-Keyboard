using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard
{
    public interface IMainForm
    {
        bool ImageCopyChecked { get; }
        string Content { get; set; }
        string SymbolCounter { get; set; }
        int CursorStartPosition { get; set; }

        event EventHandler SymbolAdded;
        event EventHandler TextCopied;
        event EventHandler ContentChanged;
        event EventHandler AboutProgram;
    }
    public partial class Main_form : Form, IMainForm
    {
        private bool IniCheck = false;
        public Main_form()
        {     
            InitializeComponent();
            IEnumerable<char> Symbols = GetList(new Symbol());

            Main_Buttons(Symbols);

            AboutBtn.Click += AboutBtn_Click;
            CopyBtn.Click += CopyBtn_Click;
            DisplayTxt.TextChanged += DisplayTxt_TextChanged;
            DisplayTxt.GotFocus += DisplayTxt_GotFocus;
        }

        #region Реализация свойств
        public string Content
        {
            get { return DisplayTxt.Text; }
            set { DisplayTxt.Text = value; }
        }

        public bool ImageCopyChecked
        {
            get { return CopyChekBox.Checked; }
        }

        public string SymbolCounter
        {
            get { return NumSymbolLbl.Text; }
            set { NumSymbolLbl.Text = value; }
        }

        public int CursorStartPosition
        {
            get { return DisplayTxt.SelectionStart; }
            set { DisplayTxt.SelectionStart = value; }
        }

        #endregion

        #region Настройка формы
        private IEnumerable<char> GetList(ISymbolSet symbol)
        {
            return symbol.Symbols;
        }

        private void Main_Buttons(IEnumerable<char> symbols)
        {
            Symbol symbol = new Symbol();

            CopyBtn.FlatAppearance.BorderSize = 0;
            CopyBtn.FlatStyle = FlatStyle.Flat;
            statusStrip1.ForeColor = Color.White;
            DisplayTxt.Font = new Font("Arial", 20);

            int HorGap = 10;
            int VertGap = 110;
            int i = 1;

            foreach (var item in symbol.Symbols)
            {
                Button newButton = new Button();
                this.Controls.Add(newButton);

                newButton.Text = item.ToString();
                newButton.Location = new Point(HorGap, VertGap);
                newButton.Size = new Size(70, 45);
                newButton.FlatAppearance.BorderSize = 0;
                newButton.FlatStyle = FlatStyle.Flat;
                newButton.BackColor = Color.DimGray;
                newButton.Font = new Font("Arial", 20);
                newButton.Click += Btn_Click;

                HorGap += newButton.Size.Width + 3;

                if (i == 14)
                {
                    VertGap += newButton.Size.Height + 3;
                    HorGap = 10;
                }

                if (i == 28)
                {
                    VertGap += newButton.Size.Height + 3;
                    HorGap = newButton.Size.Width + 13;
                }

                if (i == 40)
                {
                    VertGap += newButton.Size.Height + 3;
                    HorGap = newButton.Size.Width + 159;
                }

                i++;
            }

        }
        #endregion

        #region Проброс событий
  
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            AboutProgram?.Invoke(sender, EventArgs.Empty);
        }
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            //TextBox textBox = sender as TextBox;
            //TextCopied?.Invoke(textBox.Text, EventArgs.Empty);
            TextCopied?.Invoke(sender, EventArgs.Empty);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SymbolAdded?.Invoke(btn.Text, EventArgs.Empty);
            DisplayTxt.SelectionStart = DisplayTxt.Text.Length + 1;
        }
        private void DisplayTxt_TextChanged(object sender, EventArgs e)
        {
            IniCheck = true;
            ContentChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void DisplayTxt_GotFocus(object sender, EventArgs e)
        {
            if (!IniCheck)
                ((TextBox)sender).Parent.Focus();
        }



        public event EventHandler SymbolAdded;
        public event EventHandler TextCopied;
        public event EventHandler ContentChanged;
        public event EventHandler AboutProgram;
        #endregion
    }
}
