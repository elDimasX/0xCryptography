using System.IO;

namespace Password
{
    /// <summary>
    /// Criptografia
    /// </summary>
    class cryptography
    {
        /// <summary>
        /// Onde vamos guardar as nossas operações de criptografias feitas por mim
        /// </summary>
        public class ProgramCryptography : cryptography
        {
            /// <summary>
            /// Criptografa uma string, meu metódo porco foi feito para esse projeto
            /// Eu quero evitar o máximo o uso de outros códigos
            /// </summary>
            public static string EncryptString(string text, string password)
            {
                // Texto criptografado
                string encryptedText = "";

                // Procure todas as caracterias na senha
                foreach (char chars in password)
                {
                    // Letra
                    string c = chars.ToString();

                    // Faça uma "criptografia" básicona
                    encryptedText +=

                        // Substitua algumas caracterias
                        text.Replace(c, "Aa9d3i" + c + "3t4s22F" + c + "21dF3g4" + c + c)

                       // Outras caracterias
                       .Replace("a", "32FK3").Replace("1", "3radf4").Replace("d", "asd32rjiID")

                       // Outras caracterias
                       .Replace("e", "fgk3J").Replace("3", "f239kf3").Replace("5", "6lhg4")

                       // Outras caracterias
                       .Replace("g", "fk5k3").Replace("i", "lkh4").Replace("u", "u2").Replace("o", "5");
                }

                // Retorne a string criptografada
                return encryptedText;
            }

            /// <summary>
            /// Verifica se a senha é original igual do arquivo
            /// </summary>
            public static bool CorrectPassword(string text, string password)
            {
                // Senha criptografada no arquivo
                string readed = File.ReadAllText("C:\\ProgramData\\SuperSecretFolder\\password.txt");

                // Se a string encriptada for igual a senha lida
                if (EncryptString(text, password) == readed)
                {
                    // Senha é correta
                    return true;
                }

                // Falso
                return false;
            }
        }
    }
}
