using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace _0xCryptography
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
            // Senha usada na função de criptografia
            static string passwordForEncrypt = "testOfCryptographyTest";

            /// <summary>
            /// Criptografa uma string, meu metódo porco foi feito para esse projeto
            /// Eu quero evitar o máximo o uso de outros códigos
            /// </summary>
            public static string EncryptString(string text)
            {
                // Texto criptografado
                string encryptedText = "";

                // Procure todas as caracterias na senha
                foreach (char chars in passwordForEncrypt)
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
            public static bool CorrectPassword(string text)
            {
                // Senha criptografada no arquivo
                string readed = File.ReadAllText("C:\\ProgramData\\SuperSecretFolder\\password.txt");

                // Se a string encriptada for igual a senha lida
                if (EncryptString(text) == readed)
                {
                    // Senha é correta
                    return true;
                }

                // Falso
                return false;
            }
        }

        // Usado nas operações de criptografia e descriptografia de ARQUVIOS 
        // Máximo permitido são 8 bytes (8 caracterias), pra funcionar na função
        // De descriptografia / criptografia
        public static string passwordFiles = "dimas123";

        // Usado nas operações de criptografia e descriptografia de senhas armazenadas
        public static string passwordWebsite = "PasswordToDecryptWebsitePasswords";

        /*
        
            Código abaixo foi obtido arqui:
            https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp

            Mil perdões caso eu não tenha explicado corretamente o código abaixo
            Criptografia não é meu forte.....
         
        */

        /// <summary>
        /// Função de criptografia para string
        /// </summary>
        public static string EncryptString(string text, string password)
        {
            // Bytes do texto
            byte[] Bytes = Encoding.Unicode.GetBytes(text);

            // Criptografia AES
            Aes encryptor = Aes.Create();

            // Bytes necessário para usar em Rfc2898DeriveBytes
            byte[] bytesToDevice = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            // Rfc2898DeriveBytes, que pega a senha pra criptografia e os bytes
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, bytesToDevice);

            // Configure o encryptor
            encryptor.Key = deriveBytes.GetBytes(32);
            encryptor.IV = deriveBytes.GetBytes(16);

            // Novo MemoryStream
            MemoryStream memoryStream = new MemoryStream();

            // Crie uma criptografia
            CryptoStream cryptoStream = new CryptoStream(
                memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write
            );

            // Escreva em Bytes
            cryptoStream.Write(Bytes, 0, Bytes.Length);
            cryptoStream.Close();

            // Retorne o texto criptografado
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        /// <summary>
        /// Função de descriptografia
        /// </summary>
        public static string DecryptString(string text, string password)
        {
            // Altere o texto antes de continuar
            text = text.Replace(" ", "+");

            // Base64String
            byte[] Bytes = Convert.FromBase64String(text);

            // Criptografia AES
            Aes encryptor = Aes.Create();

            // Bytes necessário para usar em Rfc2898DeriveBytes
            byte[] bytesToDevice = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            // Rfc2898DeriveBytes, que pega a senha pra criptografia e os bytes
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, bytesToDevice);

            // Configure o encryptor
            encryptor.Key = deriveBytes.GetBytes(32);
            encryptor.IV = deriveBytes.GetBytes(16);

            // Novo MemoryStream
            MemoryStream memoryStream = new MemoryStream();

            // Crie uma descriptografia
            CryptoStream cryptoStream = new CryptoStream(
                memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write
            );

            // Escreva em Bytes
            cryptoStream.Write(Bytes, 0, Bytes.Length);
            cryptoStream.Close();

            // Retorne o texto descriptografado
            return Encoding.Unicode.GetString(memoryStream.ToArray());
        }


        /*
        
            Código abaixo foi obtido arqui:
            https://stackoverflow.com/questions/9237324/encrypting-decrypting-large-files-net/9237606

            Mil perdões caso eu não tenha explicado corretamente o código abaixo
            Criptografia não é meu forte.....
         
        */

        /// <summary>
        /// Criptografa um arquivo
        /// </summary>
        public static void EncryptFile(string file, string outputFile)
        {
            // UnicodeEncoding
            UnicodeEncoding UE = new UnicodeEncoding();

            // Obtenha os bytes
            byte[] key = UE.GetBytes(passwordFiles);

            // Novo FileStream para o outputFile
            FileStream outputCrypt = new FileStream(
                // Arquivo
                outputFile,

                // Crie o arquivo
                FileMode.Create
            );

            // Novo RijndaelManaged, usado pra criptografar
            RijndaelManaged Rijndael = new RijndaelManaged();

            // Novo CryptoStream
            CryptoStream cs = new CryptoStream(
                // Arquivo onde salvar
                outputCrypt,

                // Crie uma criptografia
                Rijndael.CreateEncryptor(key, key),

                // Escreva
                CryptoStreamMode.Write
            );

            // Novo FileStream
            FileStream stream = new FileStream(file, FileMode.Open);

            // Data
            int data;

            // Leia todos os bytes do arquivo
            while ((data = stream.ReadByte()) != -1)
            {
                // Escreva os bytes no arquivo outputFile
                cs.WriteByte((byte)data);
            }

            // Feche o arquivo original
            stream.Close();

            // Feche o outputFile
            cs.Close();

            // Feche o outputCrypt
            outputCrypt.Close();
        }

        /// <summary>
        /// Descriptografa um arquivo
        /// </summary>
        public static void DecryptFile(string inputFile, string outputFile)
        {
            // Novo UnicodeEncoding
            UnicodeEncoding UE = new UnicodeEncoding();

            // Obtenha os bytes do password
            byte[] key = UE.GetBytes(passwordFiles);

            // Abra o arquivo inputFile
            FileStream outputCrypt = new FileStream(
                // Arquivo
                inputFile,

                // Abra
                FileMode.Open
            );

            // Novo Crypto
            RijndaelManaged Rijndael = new RijndaelManaged();

            // Novo CryptoStream, usado pra criar a descriptografia
            CryptoStream cs = new CryptoStream(
                // O FileStream, que usamos pra abrir o arquivo
                outputCrypt,

                // Crie a descriptografia
                Rijndael.CreateDecryptor(key, key),

                // Leitura
                CryptoStreamMode.Read
            );

            // Novo FileStream
            FileStream stream = new FileStream(
                // Arquivo descriptografado
                outputFile,

                // Crie ele
                FileMode.Create
            );

            // Data
            int data;

            // Leita todos os bytes do CryptoStream
            while ((data = cs.ReadByte()) != -1)
            {
                // Escreva os bytes no arquivo descriptografado
                stream.WriteByte((byte)data);
            }

            // Feche o arquivo descriptografado
            stream.Close();

            // Feche o CryptoStream
            cs.Close();

            // Feche o arquivo criptografado
            outputCrypt.Close();
        }
    }
}
