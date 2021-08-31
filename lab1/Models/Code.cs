using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Models
{
    class Code : INotifyPropertyChanged
    {


        private string _inputString;
        private string _outputString;

        public Code()
        {
            this._inputString = "";
            this._outputString = "";
        }

        public string InputString
        {
            get { return _inputString; }
            set
            {
                _inputString = value;
                OnPropertyChanged();
            }
        }

        public string OutputString
        {
            get { return _outputString; }
            set
            {
                _outputString = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Алгоритм шифрования
        /// </summary>
        public void Encrypt()
        {
            OutputString = InputString + "  \nEncrypted";
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Random rand = new Random();
                    int num = rand.Next();
                    Task.Delay(100).Wait();
                    OutputString = num.ToString();
                    num++;
                }
            });
        }

        /// <summary>
        /// Алгоритм дешифрования
        /// </summary>
        public void Decrypt()
        {
            InputString = "Нас раскодировали";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
