using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0xCryptography
{
    public partial class EnterPassword : Form
    {
        // Senha não existe
        bool passwordExists = false;

        // Se permite a saida da FORM
        bool grantExit = false;

        /// <summary>
        /// Inicia tudo
        /// </summary>
        public EnterPassword()
        {
            // Altere o valor
            passwordExists = File.Exists("C:\\ProgramData\\SuperSecretFolder\\password.txt");

            InitializeComponent();

            // Se o usuário não tiver definido uma senha
            if (passwordExists == false)
            {
                Text = "Antes de continuar, defina uma senha.";
                ok.Text = "Definir senha";
            }
        }

        /// <summary>
        /// Mostra o erro
        /// </summary>
        private void ShowError(string msg)
        {
            // MessageBox
            MessageBox.Show(msg, "0xCryptography", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Botão de OK
        /// </summary>
        private void ok_Click(object sender, EventArgs e)
        {
            // Se a senha não existir, crie uma
            if (passwordExists == false)
            {
                // Se não tiver nenhuma senha definida
                if (textBox1.Text.Length == 0)
                {
                    // Mostre um MessageBox
                    ShowError("Você precisa definir uma senha!");
                }

                // Se não
                else
                {
                    // Escreva a senha no arquivo
                    File.WriteAllText(
                        // Arquivo
                        "C:\\ProgramData\\SuperSecretFolder\\password.txt",

                        // Senha criptografada
                        cryptography.ProgramCryptography.EncryptString(textBox1.Text)
                    );

                    // Permita ele sair
                    grantExit = true;

                    // Saia
                    Close();
                }
            }

            // Senha existe, verifique se ela está correta
            else
            {
                // Se a senha estiver correta
                if (cryptography.ProgramCryptography.CorrectPassword(textBox1.Text) == true)
                {
                    // Permita o programa sair
                    grantExit = true;

                    // Saia
                    Close();
                }

                // Se a senha estiver incorreta
                else
                {
                    // Erro
                    ShowError("Senha incorreta, tente novamente!");
                }
            }
        }

        /// <summary>
        /// Quando a FORM estiver fechando
        /// </summary>
        private void EnterPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Se o arquivo não existir, significa que nenhuma senha
            // Foi definida pelo usuário, neste caso, não podemos continuar
            if (!File.Exists("C:\\ProgramData\\SuperSecretFolder\\password.txt") ||

                // Se o grantExit estiver como false, significa que a senha existe
                // Mas o usuário não sabe a senha, e tentou fechar a FORM
                // Neste caso, não podemos continuar
                grantExit == false
            )
            {
                // Saia
                Environment.Exit(0);
            }
        }
    }
}
