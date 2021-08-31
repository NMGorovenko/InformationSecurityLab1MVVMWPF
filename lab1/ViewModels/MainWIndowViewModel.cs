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

        private Code _codeEncrypterDecrypter;


        // Command to append element
        private RelayCommand _encryptCommand;
        public RelayCommand EncryptCommand 
        {
            get
            {
                return _encryptCommand ?? 
                    (_encryptCommand = new RelayCommand(obj =>
                    {
                        _codeEncrypterDecrypter.Encrypt();
                    }));
            }
        }
        private RelayCommand _decryptCommand;
        public RelayCommand DecryptCommand
        {
            get
            {
                return _decryptCommand ??
                    (_decryptCommand = new RelayCommand(obj =>
                    {
                        _codeEncrypterDecrypter.Decrypt();
                    }));
            }
        }
        public Code CodeEncrypterDecrypter
        { 
            get { return _codeEncrypterDecrypter; }
            set
            {
                _codeEncrypterDecrypter = value;
                OnPropertyChanged();
            }
        }

        public MainWIndowViewModel()
        {
            this._codeEncrypterDecrypter = new Code();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
