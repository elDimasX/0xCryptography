
namespace _0xCryptography
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.removeFile = new System.Windows.Forms.Button();
            this.addFile = new System.Windows.Forms.Button();
            this.encryptedFiles = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.applicationsProtected = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.removeProgram = new System.Windows.Forms.Button();
            this.addProgram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tablePassword = new System.Windows.Forms.DataGridView();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deletePassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Location = new System.Drawing.Point(1, 66);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(633, 378);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.removeFile);
            this.tabPage1.Controls.Add(this.addFile);
            this.tabPage1.Controls.Add(this.encryptedFiles);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(625, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Arquivos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // removeFile
            // 
            this.removeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFile.Location = new System.Drawing.Point(135, 303);
            this.removeFile.Name = "removeFile";
            this.removeFile.Size = new System.Drawing.Size(105, 32);
            this.removeFile.TabIndex = 16;
            this.removeFile.Text = "Remover";
            this.removeFile.UseVisualStyleBackColor = true;
            this.removeFile.Click += new System.EventHandler(this.removeFile_Click);
            // 
            // addFile
            // 
            this.addFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFile.Location = new System.Drawing.Point(7, 303);
            this.addFile.Name = "addFile";
            this.addFile.Size = new System.Drawing.Size(105, 32);
            this.addFile.TabIndex = 15;
            this.addFile.Text = "Adicionar";
            this.addFile.UseVisualStyleBackColor = true;
            this.addFile.Click += new System.EventHandler(this.addFile_Click);
            // 
            // encryptedFiles
            // 
            this.encryptedFiles.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.encryptedFiles.AllowColumnReorder = true;
            this.encryptedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encryptedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.encryptedFiles.ForeColor = System.Drawing.Color.Black;
            this.encryptedFiles.FullRowSelect = true;
            this.encryptedFiles.GridLines = true;
            this.encryptedFiles.HideSelection = false;
            this.encryptedFiles.Location = new System.Drawing.Point(11, 43);
            this.encryptedFiles.Name = "encryptedFiles";
            this.encryptedFiles.Size = new System.Drawing.Size(591, 214);
            this.encryptedFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.encryptedFiles.TabIndex = 14;
            this.encryptedFiles.UseCompatibleStateImageBehavior = false;
            this.encryptedFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Arquivo";
            this.columnHeader2.Width = 586;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lista de arquivos criptografados";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.applicationsProtected);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.removeProgram);
            this.tabPage2.Controls.Add(this.addProgram);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(625, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Protetor de programas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // applicationsProtected
            // 
            this.applicationsProtected.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.applicationsProtected.AllowColumnReorder = true;
            this.applicationsProtected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationsProtected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.applicationsProtected.ForeColor = System.Drawing.Color.Black;
            this.applicationsProtected.FullRowSelect = true;
            this.applicationsProtected.GridLines = true;
            this.applicationsProtected.HideSelection = false;
            this.applicationsProtected.Location = new System.Drawing.Point(11, 43);
            this.applicationsProtected.Name = "applicationsProtected";
            this.applicationsProtected.Size = new System.Drawing.Size(591, 214);
            this.applicationsProtected.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.applicationsProtected.TabIndex = 12;
            this.applicationsProtected.UseCompatibleStateImageBehavior = false;
            this.applicationsProtected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Arquivo";
            this.columnHeader1.Width = 586;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(595, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Para uma melhor proteção, recomendamos você bloquear o programa: Regedit.exe";
            // 
            // removeProgram
            // 
            this.removeProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeProgram.Location = new System.Drawing.Point(135, 303);
            this.removeProgram.Name = "removeProgram";
            this.removeProgram.Size = new System.Drawing.Size(105, 32);
            this.removeProgram.TabIndex = 3;
            this.removeProgram.Text = "Remover";
            this.removeProgram.UseVisualStyleBackColor = true;
            this.removeProgram.Click += new System.EventHandler(this.removeProgram_Click);
            // 
            // addProgram
            // 
            this.addProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addProgram.Location = new System.Drawing.Point(7, 303);
            this.addProgram.Name = "addProgram";
            this.addProgram.Size = new System.Drawing.Size(105, 32);
            this.addProgram.TabIndex = 2;
            this.addProgram.Text = "Adicionar";
            this.addProgram.UseVisualStyleBackColor = true;
            this.addProgram.Click += new System.EventHandler(this.addProgram_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lista de aplicativos bloqueados:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tablePassword);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(625, 345);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Gerenciador de senhas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tablePassword
            // 
            this.tablePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePassword.BackgroundColor = System.Drawing.Color.White;
            this.tablePassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tablePassword.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Website,
            this.webPassword});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablePassword.DefaultCellStyle = dataGridViewCellStyle1;
            this.tablePassword.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tablePassword.EnableHeadersVisualStyles = false;
            this.tablePassword.Location = new System.Drawing.Point(11, 43);
            this.tablePassword.Name = "tablePassword";
            this.tablePassword.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tablePassword.ShowCellErrors = false;
            this.tablePassword.Size = new System.Drawing.Size(589, 278);
            this.tablePassword.TabIndex = 15;
            // 
            // Website
            // 
            this.Website.Frozen = true;
            this.Website.HeaderText = "Website";
            this.Website.MaxInputLength = 0;
            this.Website.MinimumWidth = 100;
            this.Website.Name = "Website";
            // 
            // webPassword
            // 
            this.webPassword.Frozen = true;
            this.webPassword.HeaderText = "Senha";
            this.webPassword.MaxInputLength = 0;
            this.webPassword.MinimumWidth = 2;
            this.webPassword.Name = "webPassword";
            this.webPassword.Width = 446;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Lista de senhas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ferramentas - 0xCryptography";
            // 
            // deletePassword
            // 
            this.deletePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deletePassword.AutoSize = true;
            this.deletePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePassword.ForeColor = System.Drawing.Color.Blue;
            this.deletePassword.Location = new System.Drawing.Point(518, 8);
            this.deletePassword.Name = "deletePassword";
            this.deletePassword.Size = new System.Drawing.Size(104, 20);
            this.deletePassword.TabIndex = 3;
            this.deletePassword.Text = "Alterar senha";
            this.deletePassword.Click += new System.EventHandler(this.deletePassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::_0xCryptography.Properties.Resources.sha_256;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 53);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 445);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.deletePassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(650, 484);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0xCryptography - ferramenta completa para operações de criptografia.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addProgram;
        private System.Windows.Forms.Button removeProgram;
        private System.Windows.Forms.Label deletePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView applicationsProtected;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView encryptedFiles;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button removeFile;
        private System.Windows.Forms.Button addFile;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView tablePassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
        private System.Windows.Forms.DataGridViewTextBoxColumn webPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

