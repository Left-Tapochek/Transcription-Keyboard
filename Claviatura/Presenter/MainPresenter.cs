using Keyboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard.Presenter
{
    public class MainPresenter
    {
        private readonly IMainForm view;
        private readonly IKeyboard keyboard;
        private readonly IMassageServise messageServise;

        public MainPresenter(IMainForm view, IKeyboard keyboard, IMassageServise messageServise)
        {
            this.view = view;
            this.keyboard = keyboard;
            this.messageServise = messageServise;

            view.SymbolAdded += SymbolAdded;
            view.TextCopied += TextCopied;
            view.ContentChanged += ContentChanged;
            view.AboutProgram += AboutProgram;
        }

        private void AboutProgram(object sender, EventArgs e)
        {
            messageServise.ShowMessege("© Transcription Keyboard, 2022. Creator: Савиных Сергей БИ-101");
        }

        private void ContentChanged(object sender, EventArgs e)
        {
            string text = view.Content;
            view.SymbolCounter = string.Format($"Number of symbols - {keyboard.CountSymbols(text)}");
        }

        private void TextCopied(object sender, EventArgs e)
        {
            try
            {
                string text = string.Format($"[{view.Content}]");

                if (view.ImageCopyChecked)
                {
                    keyboard.TextToImageCopy(text);
                    messageServise.ShowMessege("Copied as image");
                }

                else
                {
                    keyboard.TextCopy(text);
                    messageServise.ShowMessege("Copied as text");
                }
            }

            catch (Exception ex)
            {
                messageServise.showError($"Text copied error {ex.Message}");
            }

        }

        private void SymbolAdded(object sender, EventArgs e)
        {
            try
            {
                string text = keyboard.SetText(view.CursorStartPosition, view.Content, (string)sender);
                view.Content = text;
            }
            catch (Exception ex)
            {
                messageServise.showError($"Symbol adding error {ex.Message}");
            }

        }
    }
}
