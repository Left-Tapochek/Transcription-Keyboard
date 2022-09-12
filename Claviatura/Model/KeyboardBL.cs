using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard.Model
{
    public interface IKeyboard
    {
        string SetText(int startPosition, string text, string symbol);
        void TextCopy(string text);
        void TextToImageCopy(string text);
        int CountSymbols(string text);
    }
    public class KeyboardBL : IKeyboard
    {
        public int CountSymbols(string text)
        {
            return text.Length;
        }

        public string SetText(int startPosition, string text, string symbol)
        {
            if (text.Length == startPosition)
            {
                return text += symbol;
            }
            else
            {
                return text.Insert(startPosition, symbol);
            }
        }

        public void TextCopy(string text)
        {
            Clipboard.SetText(text);
        }

        public void TextToImageCopy(string text)
        {
            Bitmap bitmap = new Bitmap(text.Length * 22, 50, PixelFormat.Format64bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.DrawString(text, new Font("Arial", 30, FontStyle.Regular), new SolidBrush(Color.FromArgb(0, 0, 0)), new PointF(0.4F, 2.4F));

            Clipboard.SetImage(bitmap);
            bitmap.Dispose();
        }
    }
}
