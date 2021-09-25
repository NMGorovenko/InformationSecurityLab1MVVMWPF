using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Models
{
    class Code : INotifyPropertyChanged
    {


        private string _inputString;
        private string _outputString;
        private string _key;
        
        public Code()
        {
            _inputString = "";
            _outputString = "";
        }

        public string InputString
        {
            get { return _inputString; }
            set
            {
                _inputString = value.ToLower();
                OnPropertyChanged();
            }
        }

        public string OutputString
        {
            get { return _outputString; }
            set
            {
                _outputString = value.ToLower();
                OnPropertyChanged();
            }
        }
        
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                OnPropertyChanged();
            }
        }

        
        public virtual void Encrypt()
        {
            OutputString = InputString + "  \nEncrypted";
            
        }

        public virtual void EncryptImprove()
        {
            OutputString = InputString + "  \nEncrypted";

        }
        public virtual void Decrypt()
        {
            InputString = "Нас раскодировали";
        }
        public virtual void DecryptImprove()
        {
            InputString = "Нас раскодировали";
        }

        public void SwapAndCleanOutputString()
        {
            string temp = new string(InputString);
            InputString = new string(OutputString);
            OutputString = "";
        }

        public async void ReadFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    InputString = await sr.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
