using Microsoft.Win32;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace _0xCryptography
{
    public partial class Form1 : Form
    {
        // Local do regedit
        string regFolder = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\";

        // Pasta onde vamos armazenar alguams coisas
        string folder = "C:\\ProgramData\\SuperSecretFolder\\";

        // Pasta dos programas protegidos
        string folderApplication = "C:\\ProgramData\\SuperSecretFolder\\Applications\\";

        // Pasta das senhas
        string folderWebsite = "C:\\ProgramData\\SuperSecretFolder\\Passwords\\";

        // Arquivos criptografados
        string filesEncrypted = "C:\\ProgramData\\SuperSecretFolder\\files.txt";

        // Onde realmente vai ficar o password.exe
        string copyPassword = "C:\\Windows\\writerpower.exe";

        /// <summary>
        /// Altera as configurações de segurança em um valor no registro
        /// Porque assim, o password.exe vai poder modifica-lós sem precisar
        /// Ser administrador
        /// </summary>
        private void SetAclOnRegistry()
        {
            try
            {
                // Se a pasta que vamos usar não existir
                if (!Directory.Exists(folderApplication))
                {
                    // Crie ela
                    Directory.CreateDirectory(folderApplication);
                }

                try
                {
                    // Oculte a pasta
                    File.SetAttributes(folder, FileAttributes.System | FileAttributes.Hidden);
                } catch (Exception) { }

                // Key
                RegistryKey key;

                // A chave que queremos alterar as permissões
                key = Registry.LocalMachine.OpenSubKey(
                    // Local
                    regFolder,

                    // Permissão de escrever e ler
                    RegistryKeyPermissionCheck.ReadWriteSubTree,
                    
                    // Tomar posse da chave, porque o properietario dela
                    // É "SISTEMA", e não estamos executando neste nível
                    // Portanto, essa parte é necessária
                    RegistryRights.TakeOwnership);

                // Novo RegistrySecurity
                RegistrySecurity security = new RegistrySecurity();

                // Agora, adiciona a permissão de segurança
                security.AddAccessRule(new RegistryAccessRule(

                    // Usuário (Todos)
                    "Todos",

                    // Permissão de escrita
                    RegistryRights.WriteKey |

                    // Ler as chaves
                    RegistryRights.ReadKey |

                    // Controle máximo
                    RegistryRights.FullControl |

                    // Deletar as chaves
                    RegistryRights.Delete,

                    // Pastas e subpastas
                    InheritanceFlags.ContainerInherit |
                    InheritanceFlags.ObjectInherit,

                    // Objetos filhos
                    PropagationFlags.InheritOnly,

                    // Permita em vez de negar
                    AccessControlType.Allow
                ));

                // Sete o acesso
                key.SetAccessControl(security);
            } catch (Exception ex)
            {
                // Se falhar, mostre uma mensagem
                ShowError(ex.Message);

                // Sem acesso ao registro, não poderemos continuar
                Environment.Exit(0);
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
        /// Adiciona um programa protegido á lista
        /// </summary>
        private void AddOnList(string filename)
        {
            try
            {
                // Crie o arquivo para informar que protegemos ele
                File.Create(folderApplication + filename).Close();

                // Adicione o arquivo á listBox
                applicationsProtected.Items.Add(filename);
            } catch (Exception ex)
            {
                // Se falhar, mostre a mensagem
                ShowError(ex.Message);
            }
            
        }

        /// <summary>
        /// Obtém todos os programas protegidos
        /// </summary>
        private void GetProtectedPrograms()
        {
            try
            {
                // Limpe
                applicationsProtected.Items.Clear();

                // Obtenha todos os arquivos na pastas, eles são criados
                // Quando um programa é protegido
                foreach (string files in Directory.GetFiles(folderApplication))
                {
                    // Somente o nome
                    string fileName = Path.GetFileName(files);

                    // Adicione a lista
                    ListViewItem item = new ListViewItem(fileName);

                    // Adicione o item
                    applicationsProtected.Items.Add(item);
                }
            } catch (Exception)
            {
            }
        }

        /// <summary>
        /// Obtém todos os arquivos já criptografados
        /// </summary>
        private void GetProtectedFiles()
        {
            try
            {
                // Se o arquivo não existir
                if (!File.Exists(filesEncrypted))
                {
                    // Crie ele
                    File.Create(filesEncrypted).Close();

                    // Pare, porque ele acabou de ser criado
                    // E não possui nada
                    return;
                }

                // Leia linha por linha
                foreach (string line in File.ReadAllLines(filesEncrypted))
                {
                    // Se for maior que 0
                    if (line.Length > 0)
                    {
                        // Adiciona a lista
                        encryptedFiles.Items.Add(line);
                    }
                }
            } catch (Exception ex)
            {
                // Se falhar
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza a lista, usado para adicionar / remover arquivos criptografados
        /// </summary>
        private void UpdateList()
        {
            try
            {
                // Apague todo o conteúdo do arquivo antes de adicionar
                // Os novos
                File.WriteAllText(filesEncrypted, "");

                // Procure todos os itens na listViews
                foreach (ListViewItem item in encryptedFiles.Items)
                {
                    // Adicione o arquivo
                    File.AppendAllText(filesEncrypted, item.Text + Environment.NewLine);
                }
            } catch (Exception ex)
            {
                // Se falhar
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Obtém as senhas armazenadas
        /// </summary>
        private void GetPasswords()
        {
            try
            {
                // Se a pasta não existir
                if (!Directory.Exists(folderWebsite))
                {
                    // Crie
                    Directory.CreateDirectory(folderWebsite);

                    // Pare, pois nada foi armazenado
                    return;
                }

                // Obtenha os arquivos na pasta
                foreach (string file in Directory.GetFiles(folderWebsite))
                {
                    // Texto descriptografado
                    string decryptedText = cryptography.DecryptString(File.ReadAllText(file), cryptography.passwordWebsite);

                    // Adicione o valor
                    tablePassword.Rows.Add(Path.GetFileName(file), decryptedText);
                }
            } catch (Exception) { }
        }

        /// <summary>
        /// Verifica se a senha existe, se não, ele cria e depois
        /// Pede ela
        /// </summary>
        private void Password()
        {
            try
            {
                // Mostre a tela pra pedir senha, ou criar uma
                EnterPassword enterPassword = new EnterPassword();
                enterPassword.ShowDialog();
            } catch (Exception ex)
            {
                // Mostre o erro caso falhe
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Obtém o MD5 de um arquivo
        /// </summary>
        private string GetMd5(string file)
        {
            // Agora, a gente precisa verificar o MD5 do password.exe, porque
            // Se não fizermos, alguém poderá colocar outro executável no lugar
            // E infectar o usuário
            MD5 md5 = MD5.Create();

            // FileStream
            FileStream stream = new FileStream(
                // Arquivo
                file,

                // Abra ele
                FileMode.Open,

                // Com permissão de leitura
                FileAccess.Read,

                // Enquanto estivermos trabalhando com o arquivo, não permita
                // Que ele seja modificado
                FileShare.None
            );

            // Bytes do MD5
            byte[] md5Byte = md5.ComputeHash(stream);

            // Agora, obtenha a string do MD5, e depois, iremos verificar
            string md5String = BitConverter.ToString(md5Byte).ToUpper().Replace("-", "");

            // Feche o arquivo
            stream.Close();

            // Retorne o MD5
            return md5String;
        }

        /// <summary>
        /// Copia o arquivo Password.exe para outra pasta, e verifica o MD5
        /// Dele também, pois pode até ser um malware
        /// </summary>
        private void CopyPasswordExe()
        {
            try
            {
                // Local do password.exe
                string passwordExe = Application.StartupPath + "\\Password.exe";

                // Se o arquivo existir nesta pasta
                if (File.Exists(copyPassword))
                {
                    // Se o MD5 do arquivo já copiado for original
                    if (GetMd5(copyPassword) == "63E00296E90466E6928E8A7A0C1230E5")
                    {
                        // O arquivo é original, não precisamos nós preocupar
                        // Então, pare
                        return;
                    }

                    // Devemos deletar, porque a versão que possuimos a vez, pode ter
                    // Sido mais atualizada, dai ele já vai copiar a versão mais recente
                    // Pra lá
                    File.Delete(copyPassword);
                }

                // Agora, verifica o MD5 para certificar que ele realmente
                // É autêntico
                if (GetMd5(passwordExe) != "63E00296E90466E6928E8A7A0C1230E5")
                {
                    // O MD5 do arquivo foi modificado, então, não podemos continuar
                    Environment.Exit(0);
                }

                // Copie o arquivo pra pasta
                File.Copy(passwordExe, copyPassword);

                // Agora, oculte o local
                File.SetAttributes(copyPassword, FileAttributes.Hidden | FileAttributes.System);
            } catch (Exception)
            {
                // Se falhar, não podemos continuar, porque a função de protetor
                // De programas não vai funcionar
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Inicia a FORM
        /// </summary>
        public Form1()
        {
            // Sete as configurações de segurança no registro
            SetAclOnRegistry();

            // Copie o Passwor.exe para um lugar seguro
            CopyPasswordExe();

            // Inicie a FORM
            InitializeComponent();

            // Sete o cursor mais bonito nos controles
            DllCursor.SetHandCursor(this);

            // Obtenha todos os arquivos criptografados
            GetProtectedFiles();

            // Obtenha os programas já protegidos
            GetProtectedPrograms();

            // Obtenha as senhas armazenadas
            GetPasswords();

            // Verifique a senha
            Password();
        }

        /// <summary>
        /// Botão de adicionar programas
        /// </summary>
        private void addProgram_Click(object sender, EventArgs e)
        {
            // OpenFileDialog, usado para selecionar arquivos
            OpenFileDialog dialog = new OpenFileDialog();

            // Somente arquivos com extensão .EXE
            dialog.Filter = "|*.exe";

            // Pasta inicial é a Área de Trabalho do usuário
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Pode selecionar mais de um arquivo por vez
            dialog.Multiselect = true;

            // Se o usuário selecionou os arquivos e clicou em OK
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Procure todos os arquivos selecionados
                foreach (string files in dialog.FileNames)
                {
                    // Somente o nome do arquivo
                    string fileName = Path.GetFileName(files);

                    // Novo RegistryKey
                    RegistryKey key;

                    // Abra a pasta
                    key = Registry.LocalMachine.OpenSubKey(regFolder, true);

                    // Crie uma chave lá no registro
                    key.CreateSubKey(fileName, true);

                    // Agora, abra a chave que a gente criou
                    key = Registry.LocalMachine.OpenSubKey(regFolder + fileName, true);

                    // Sete o valor para que o programa não seja aberto
                    // Em vez disso, ele inicia o Password.exe
                    key.SetValue(
                        // Nome do valor
                        "Debugger",

                        // Valor
                        '"' + copyPassword + '"',
                        
                        // Tipo string
                        RegistryValueKind.String
                    );

                    // Adicione na lista
                    AddOnList(fileName);

                    // Terminamos
                    key.Close();
                }
            }
        }

        /// <summary>
        /// Botão de remover programa
        /// </summary>
        private void removeProgram_Click(object sender, EventArgs e)
        {
            try
            {
                // Se nenhum item for selecionado
                if (applicationsProtected.SelectedItems.Count == 0)
                {
                    // Pare
                    return;
                }

                // Procure todos os itens selecionados
                foreach (ListViewItem selected in applicationsProtected.SelectedItems)
                {
                    // Novo RegistryKey
                    RegistryKey key;

                    // Abra a chave no registro
                    key = Registry.LocalMachine.OpenSubKey(regFolder, true);

                    // Delete o valor de lá
                    key.DeleteSubKey(selected.Text);

                    // Feche a chave
                    key.Close();

                    // Delete o arquivo
                    File.Delete(folderApplication + selected.Text);
                }
            } catch (Exception ex)
            {
                // Se falhar, mostre uma mensagem
                ShowError(ex.Message);
            }

            // Atualize a lista
            GetProtectedPrograms();
        }

        /// <summary>
        /// Deletar a senha atual
        /// </summary>
        private void deletePassword_Click(object sender, EventArgs e)
        {
            // Se ele confirmar que deseja apagar a senha atual
            if (
                MessageBox.Show("Tem certeza que deseja alterar sua senha?", "0xCryptography", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK
            )
            {
                // Delete o arquivo
                File.Delete(folder + "password.txt");

                // Peça pra criar uma nova senha
                Password();
            }
        }

        /// <summary>
        /// Adiciona um arquivo para criptografar
        /// </summary>
        private void addFile_Click(object sender, EventArgs e)
        {
            // Novo dialogo
            OpenFileDialog dialog = new OpenFileDialog();

            // Todos os arquivos
            dialog.Filter = "|*.*";

            // Pode selecionar mais de um
            dialog.Multiselect = true;

            // Se o usuário terminar
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Procure todos os arquivos selecionados pelo usuário
                foreach (string file in dialog.FileNames)
                {
                    try
                    {

                        // Se o arquivo não existir
                        if (!File.Exists(filesEncrypted))
                        {
                            // Crie o arquivo
                            File.Create(filesEncrypted).Close();
                        }

                        // Criptografe o arquivo
                        cryptography.EncryptFile(file, file + ".encrypted");

                        // Adicione ao arquivo files.txt, para o programa
                        // Saber quais arquivos o usuário já criptografou
                        File.AppendAllText(filesEncrypted, file + ".encrypted" + Environment.NewLine);

                        // Delete o arquivo anterior
                        File.Delete(file);

                        // Adicione a lista
                        encryptedFiles.Items.Add(file + ".encrypted");
                    }
                    catch (Exception ex)
                    {
                        // Se falhar, moste o erro
                        ShowError(ex.Message);
                    }

                    // Atualize a lista
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// Botão de remover arquivo criptografado
        /// </summary>
        private void removeFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Se nenhum objeto da lista for selecionado
                if (encryptedFiles.SelectedItems.Count == 0)
                {
                    // Pare
                    return;
                }

                // Texto que contém todos os arquivos criptografados
                string allFiles = File.ReadAllText(filesEncrypted);

                // Leia linha por linha nos arquivos que é salvado
                // Quando um arquivo é criptografado
                foreach (ListViewItem line in encryptedFiles.SelectedItems)
                {
                    // Texto
                    string lineText = line.Text;

                    // Remova o arquivo
                    encryptedFiles.Items.Remove(line);

                    // Se o arquivo não existir
                    if (!File.Exists(lineText))
                    {
                        // Atualize a lista
                        UpdateList();

                        // Pare
                        return;
                    }

                    // Local do arquivos descriptografado
                    string location = Path.GetDirectoryName(lineText) + "\\" + Path.GetFileNameWithoutExtension(lineText);

                    // Descriptografe o arquivo
                    cryptography.DecryptFile(lineText, location);

                    // Delete o arquivo com extensão .encrypted
                    File.Delete(lineText);
                }

                // Atualize a lista
                UpdateList();
            } catch (Exception ex)
            {
                // Se falhar, mostre uma mensagem
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Salva as senhas armazenadas
        /// </summary>
        private void SavePasswords()
        {
            // Se a pasta existir
            if (Directory.Exists(folderWebsite))
            {
                // Delete ela para apagar as senhas antigas
                Directory.Delete(folderWebsite, true);
            }

            try
            {
                // Crie a pasta novamente
                Directory.CreateDirectory(folderWebsite);
            } catch (Exception) { }

            // Procure todo os itens na tabela
            foreach (DataGridViewRow item in tablePassword.Rows)
            {
                try
                {
                    // Senhas
                    string senha = item.Cells["webPassword"].Value?.ToString();

                    // Website
                    // Usei o "?" porque quando ele for nulo, não retornará
                    // Um erro
                    string website = item.Cells["Website"].Value?.ToString();

                    // Se nada estiver escrito na senha
                    if (senha == null)
                    {
                        try
                        {
                            // Delete o arquivo, pois não tem senha
                            File.Delete(folderWebsite + website);

                            // Pare
                            return;
                        }
                        catch (Exception) { }
                    }

                    // Escreva no arquivo
                    File.WriteAllText(
                        // Arquivo
                        folderWebsite + website,

                        // Criptografado
                        cryptography.EncryptString(senha, cryptography.passwordWebsite)
                    );
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Quando a FORM estiver sendo fechada
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Salva as senhas
            SavePasswords();
        }
    }
}
