namespace lab1.Models
{
    /// <summary>
    /// Шифр Вижинера
    /// </summary>
    internal class VigenerCode : Code
    {
        private const string _alphabetEn = "abcdefghijklmnopqrstuvwxyz ";
        private string _words;


        public override void Encrypt()
        {
            _words = new string(InputString);
            string result = "";

            // шифрование
            if (!string.IsNullOrEmpty(Key))
            {
                for (int i = 0; i < _words.Length; i++)
                {
                    var index = _alphabetEn.IndexOf(_words[i]) + _alphabetEn.IndexOf(Key[i % Key.Length]);
                    index %= _alphabetEn.Length;
                    result += _alphabetEn[index];
                }
            }
            

            OutputString = result;
        }

        public override void Decrypt()
        {
            _words = new string(InputString);
            string result = "";

            // дешифрование
            if (!string.IsNullOrEmpty(Key))
            {
                for (int i = 0; i < _words.Length; i++)
                {
                    var index = _alphabetEn.IndexOf(_words[i]) - _alphabetEn.IndexOf(Key[i % Key.Length]) +
                                _alphabetEn.Length;
                    index %= _alphabetEn.Length;
                    result += _alphabetEn[index];
                }
            }

            OutputString = result;
        }
    }
}
