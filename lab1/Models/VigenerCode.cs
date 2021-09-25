using System;

namespace lab1.Models
{
    /// <summary>
    /// Шифр Вижинера
    /// </summary>
    internal class VigenerCode : Code
    {
        private const string _alphabet = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя  .,'`!#№$~0123456789";
        private string _words;


        public override void Encrypt()
        {
            _words = new string(InputString);
            string result = "";

            // шифрование
            try
            {
                if (!string.IsNullOrEmpty(Key))
                {
                    for (int i = 0; i < _words.Length; i++)
                    {
                        var index = _alphabet.IndexOf(_words[i]) + _alphabet.IndexOf(Key[i % Key.Length]);
                        index += _alphabet.Length;
                        index %= _alphabet.Length;
                        result += _alphabet[index];
                    }
                }
                OutputString = result;
            }
            catch (IndexOutOfRangeException exception)
            {
                OutputString = "Ошибка шифрования";
            }
        }

        // усовершенствованный алгоритм шифрования
        public override void EncryptImprove()
        {
            _words = new string(InputString);
            string result = "";

            // шифрование
            try
            {
                if (!string.IsNullOrEmpty(Key))
                {
                    int shift = 0;
                    for (int i = 0;  i < _words.Length; i++)
                    {
                        var index = _alphabet.IndexOf(_words[i]) + _alphabet.IndexOf(Key[i % Key.Length]) + _alphabet.Length;
                        index += shift; // делаем сдвиг по индексу
                        index %= _alphabet.Length;
                        result += _alphabet[index];
                        shift++;
                    }
                }
                OutputString = result;
            }
            catch (IndexOutOfRangeException exception)
            {
                OutputString = "Ошибка шифрования";
            }
        }

        public override void Decrypt()
        {
            _words = new string(InputString);
            string result = "";

            try
            {
                // дешифрование
                if (!string.IsNullOrEmpty(Key))
                {
                    for (int i = 0; i < _words.Length; i++)
                    {
                        var index = _alphabet.IndexOf(_words[i]) - _alphabet.IndexOf(Key[i % Key.Length]) + _alphabet.Length;
                        index %= _alphabet.Length;
                        result += _alphabet[index];
                    }
                }
                OutputString = result;
            }

            catch (IndexOutOfRangeException exception)
            {
                OutputString = "Ошибка шифрования";
            }
        }

        public override void DecryptImprove()
        {
            _words = new string(InputString);
            string result = "";

            try
            {
                // дешифрование
                if (!string.IsNullOrEmpty(Key))
                {
                    int shift = 0;
                    for (int i = 0; i < _words.Length; i++)
                    {
                        var index = _alphabet.IndexOf(_words[i]) - _alphabet.IndexOf(Key[i % Key.Length]) + _alphabet.Length;
                        index -= shift;
                        index %= _alphabet.Length;
                        result += _alphabet[index];
                        shift++;
                    }
                }
                OutputString = result;
            }

            catch (IndexOutOfRangeException exception)
            {
                OutputString = "Ошибка шифрования";
            }
        }
    }
}
