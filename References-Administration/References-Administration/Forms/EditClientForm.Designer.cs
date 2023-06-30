
namespace References_Administration
{
    partial class EditClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DepartmentsNameListBox = new System.Windows.Forms.ListBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordRetryTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FullName = new System.Windows.Forms.TextBox();
            this.LastPasswordLabel = new System.Windows.Forms.Label();
            this.LastPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(52, 113);
            this.LoginTextBox.Multiline = true;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(577, 33);
            this.LoginTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Подразделение";
            // 
            // DepartmentsNameListBox
            // 
            this.DepartmentsNameListBox.FormattingEnabled = true;
            this.DepartmentsNameListBox.Location = new System.Drawing.Point(52, 308);
            this.DepartmentsNameListBox.Name = "DepartmentsNameListBox";
            this.DepartmentsNameListBox.Size = new System.Drawing.Size(577, 69);
            this.DepartmentsNameListBox.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(56, 397);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(113, 31);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Отменить";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(285, 397);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(113, 31);
            this.CreateButton.TabIndex = 9;
            this.CreateButton.Text = "Создать";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(516, 397);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(113, 31);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(53, 97);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 13);
            this.labelLogin.TabIndex = 11;
            this.labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(53, 160);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = " Пароль";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(52, 176);
            this.PasswordTextBox.Multiline = true;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(577, 33);
            this.PasswordTextBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Повторите пароль";
            // 
            // PasswordRetryTextBox
            // 
            this.PasswordRetryTextBox.Location = new System.Drawing.Point(52, 237);
            this.PasswordRetryTextBox.Multiline = true;
            this.PasswordRetryTextBox.Name = "PasswordRetryTextBox";
            this.PasswordRetryTextBox.Size = new System.Drawing.Size(577, 33);
            this.PasswordRetryTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "ФИО";
            // 
            // FullName
            // 
            this.FullName.Location = new System.Drawing.Point(52, 52);
            this.FullName.Multiline = true;
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(577, 33);
            this.FullName.TabIndex = 17;
            // 
            // LastPasswordLabel
            // 
            this.LastPasswordLabel.AutoSize = true;
            this.LastPasswordLabel.Location = new System.Drawing.Point(53, 97);
            this.LastPasswordLabel.Name = "LastPasswordLabel";
            this.LastPasswordLabel.Size = new System.Drawing.Size(84, 13);
            this.LastPasswordLabel.TabIndex = 18;
            this.LastPasswordLabel.Text = "Старый пароль";
            // 
            // LastPasswordTextBox
            // 
            this.LastPasswordTextBox.Location = new System.Drawing.Point(52, 113);
            this.LastPasswordTextBox.Multiline = true;
            this.LastPasswordTextBox.Name = "LastPasswordTextBox";
            this.LastPasswordTextBox.Size = new System.Drawing.Size(577, 33);
            this.LastPasswordTextBox.TabIndex = 19;
            // 
            // EditClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LastPasswordTextBox);
            this.Controls.Add(this.LastPasswordLabel);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordRetryTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DepartmentsNameListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginTextBox);
            this.Name = "EditClientForm";
            this.Text = "EditClientForm";
            this.Load += new System.EventHandler(this.EditClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DepartmentsNameListBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordRetryTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FullName;
        private System.Windows.Forms.Label LastPasswordLabel;
        private System.Windows.Forms.TextBox LastPasswordTextBox;
    }
}