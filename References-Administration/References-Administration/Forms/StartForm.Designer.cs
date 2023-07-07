
namespace References_Administration
{
    partial class StartForm
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
            this.DepartmentButton = new System.Windows.Forms.Button();
            this.DirectoryButton = new System.Windows.Forms.Button();
            this.authorizationButton = new System.Windows.Forms.Button();
            this.LogintextBox = new System.Windows.Forms.TextBox();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelCurrentSession = new System.Windows.Forms.Label();
            this.buttonEvents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DepartmentButton
            // 
            this.DepartmentButton.Location = new System.Drawing.Point(277, 48);
            this.DepartmentButton.Name = "DepartmentButton";
            this.DepartmentButton.Size = new System.Drawing.Size(197, 56);
            this.DepartmentButton.TabIndex = 0;
            this.DepartmentButton.Text = "Администрирование";
            this.DepartmentButton.UseVisualStyleBackColor = true;
            this.DepartmentButton.Click += new System.EventHandler(this.Administration_Click);
            // 
            // DirectoryButton
            // 
            this.DirectoryButton.Location = new System.Drawing.Point(277, 125);
            this.DirectoryButton.Name = "DirectoryButton";
            this.DirectoryButton.Size = new System.Drawing.Size(197, 56);
            this.DirectoryButton.TabIndex = 1;
            this.DirectoryButton.Text = "Справочники";
            this.DirectoryButton.UseVisualStyleBackColor = true;
            this.DirectoryButton.Click += new System.EventHandler(this.Directory_Click);
            // 
            // authorizationButton
            // 
            this.authorizationButton.Location = new System.Drawing.Point(314, 386);
            this.authorizationButton.Name = "authorizationButton";
            this.authorizationButton.Size = new System.Drawing.Size(125, 28);
            this.authorizationButton.TabIndex = 2;
            this.authorizationButton.Text = "Авторизироваться";
            this.authorizationButton.UseVisualStyleBackColor = true;
            this.authorizationButton.Click += new System.EventHandler(this.authorizationButton_Click);
            // 
            // LogintextBox
            // 
            this.LogintextBox.Location = new System.Drawing.Point(289, 305);
            this.LogintextBox.Name = "LogintextBox";
            this.LogintextBox.Size = new System.Drawing.Size(185, 20);
            this.LogintextBox.TabIndex = 3;
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(289, 360);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.Size = new System.Drawing.Size(185, 20);
            this.PasswordtextBox.TabIndex = 4;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(286, 289);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 13);
            this.labelLogin.TabIndex = 5;
            this.labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(286, 344);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(45, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Пароль";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(314, 386);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(125, 28);
            this.buttonLogOut.TabIndex = 7;
            this.buttonLogOut.Text = "Выйти";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelCurrentSession
            // 
            this.labelCurrentSession.AutoSize = true;
            this.labelCurrentSession.Location = new System.Drawing.Point(293, 363);
            this.labelCurrentSession.Name = "labelCurrentSession";
            this.labelCurrentSession.Size = new System.Drawing.Size(38, 13);
            this.labelCurrentSession.TabIndex = 8;
            this.labelCurrentSession.Text = "Логин";
            // 
            // buttonEvents
            // 
            this.buttonEvents.Location = new System.Drawing.Point(277, 200);
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Size = new System.Drawing.Size(197, 56);
            this.buttonEvents.TabIndex = 9;
            this.buttonEvents.Text = "Совещания";
            this.buttonEvents.UseVisualStyleBackColor = true;
            this.buttonEvents.Click += new System.EventHandler(this.buttonEvents_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEvents);
            this.Controls.Add(this.labelCurrentSession);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.PasswordtextBox);
            this.Controls.Add(this.LogintextBox);
            this.Controls.Add(this.authorizationButton);
            this.Controls.Add(this.DirectoryButton);
            this.Controls.Add(this.DepartmentButton);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DepartmentButton;
        private System.Windows.Forms.Button DirectoryButton;
        private System.Windows.Forms.Button authorizationButton;
        private System.Windows.Forms.TextBox LogintextBox;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label labelCurrentSession;
        private System.Windows.Forms.Button buttonEvents;
    }
}