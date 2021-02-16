using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password
{
    public partial class Form1 : Form
    {
        // Aplicativo para desbloquear
        string applicationToUnlock = "";

        // Local no regedit
        string regFolder = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\";

        /// <summary>
        /// Inicia tudo
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            try
            {
                // Obtem os argumentos passados no executável
                string[] argumentos = Environment.GetCommandLineArgs();

                // Altere o applicationToUnlock, que foi passado no registro
                // Para que possamos detectar qual aplicativo o usuário está tentando acessar
                applicationToUnlock = Path.GetFileName(argumentos[1]);
            } catch (Exception) { }
        }

        /// <summary>
        /// Depois de clicar em OK
        /// </summary>
        private async void ok_Click(object sender, EventArgs e)
        {
            // Se senha estiver certa
            if (cryptography.ProgramCryptography.CorrectPassword(textBox1.Text, "testOfCryptographyTest") == true)
            {
                // Oculte-nós
                Hide();

                // Minize a nossa FORM
                WindowState = FormWindowState.Minimized;
                
                // Novo RegistryKey
                RegistryKey key;

                // Abra uma chave
                key = Registry.LocalMachine.OpenSubKey(
                    // Local
                    regFolder + applicationToUnlock,

                    // Escrever
                    true
                );

                // Obtenha o valor antigo
                string oldValue = key.GetValue("Debugger").ToString();

                // Delete o valor
                key.SetValue("Debugger", "", RegistryValueKind.String);

                // Inicie um novo thread para esse executável, porque se não
                // O código vai esperar o programa ser finalizado
                new Thread(() =>
                {
                    // Inicie o aplicativo
                    Process.Start(applicationToUnlock);
                }).Start();

                // Espere um segundo para que processo possa ser iniciado
                await Task.Delay(1000);

                // Adiciona o valor para bloquear novamente
                key.SetValue("Debugger", oldValue, RegistryValueKind.String);

                // Feche a chave
                key.Close();

                Environment.Exit(0);
            }

            // Se a senha estiver errada
            else
            {
                // Mostre uma mensagem de erro
                MessageBox.Show("Senha incorreta, tente novamente.", "0xCryptography", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
