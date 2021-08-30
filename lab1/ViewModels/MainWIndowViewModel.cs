using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using lab1.Models;
using lab1.Commands;
using System.Runtime.CompilerServices;

namespace lab1.ViewModels
{
    class MainWIndowViewModel : INotifyPropertyChanged
    {

        private Code codeEncrypterDecrypter;


        // Command to append element
        private RelayCommand encryptCommand;
        public RelayCommand EncryptCommand 
        {
            get
            {
                return encryptCommand ?? 
                    (encryptCommand = new RelayCommand(obj =>
                    {
                        codeEncrypterDecrypter.Encrypt();
                    }));
            }
        }
        private RelayCommand decryptCommand;
        public RelayCommand DecryptCommand
        {
            get
            {
                return decryptCommand ??
                    (decryptCommand = new RelayCommand(obj =>
                    {
                        codeEncrypterDecrypter.Decrypt();
                    }));
            }
        }
        public Code CodeEncrypterDecrypter
        { 
            get { return codeEncrypterDecrypter; }
            set
            {
                codeEncrypterDecrypter = value;
                OnPropertyChanged();
            }
        }

        public MainWIndowViewModel()
        {
            this.codeEncrypterDecrypter = new Code();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
