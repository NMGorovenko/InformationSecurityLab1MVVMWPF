using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using lab1.Models;
using lab1.Commands;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using System.IO;

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

        private RelayCommand _swapAndCleanOutputCommand;
        public RelayCommand SwapAndCleanOutputString
        {
            get
            {
                return _swapAndCleanOutputCommand ??
                       (_swapAndCleanOutputCommand = new RelayCommand(obj =>
                       {
                           _codeEncrypterDecrypter.SwapAndCleanOutputString();
                       }));
            }
        }

        private RelayCommand _openFileInput;
        public RelayCommand OpenFileInput
        {
            get
            {
                return _openFileInput ??
                       (_openFileInput = new RelayCommand(obj =>
                       {
                           string fileLocation = GetPath();
                           CodeEncrypterDecrypter.ReadFromFile(fileLocation);
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

        public string GetPath()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }

        public MainWIndowViewModel()
        {
            this._codeEncrypterDecrypter = new VigenerCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
