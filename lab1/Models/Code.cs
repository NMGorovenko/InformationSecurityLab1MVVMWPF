using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace lab1.Models
{
    class Code : INotifyPropertyChanged
    {


        string inputString;
        string outputString;

        public Code()
        {
            this.inputString = "";
            this.outputString = "";
        }

        public string InputString
        {
            get { return inputString; }
            set
            {
                inputString = value;
                OnPropertyChanged();
            }
        }

        public string OutputString
        {
            get { return outputString; }
            set
            {
                outputString = value;
                OnPropertyChanged();
            }
        }

        // алгоритм шифрования
        public void Encrypt()
        {
            OutputString = InputString + "  \nEncrypted";
            
        }

        public void Decrypt()
        {
            InputString = "Нас раскодировали";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
