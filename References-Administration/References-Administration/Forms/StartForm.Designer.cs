
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
            this.SuspendLayout();
            // 
            // DepartmentButton
            // 
            this.DepartmentButton.Location = new System.Drawing.Point(277, 97);
            this.DepartmentButton.Name = "DepartmentButton";
            this.DepartmentButton.Size = new System.Drawing.Size(197, 56);
            this.DepartmentButton.TabIndex = 0;
            this.DepartmentButton.Text = "Администрирование";
            this.DepartmentButton.UseVisualStyleBackColor = true;
            this.DepartmentButton.Click += new System.EventHandler(this.Administration_Click);
            // 
            // DirectoryButton
            // 
            this.DirectoryButton.Location = new System.Drawing.Point(277, 193);
            this.DirectoryButton.Name = "DirectoryButton";
            this.DirectoryButton.Size = new System.Drawing.Size(197, 56);
            this.DirectoryButton.TabIndex = 1;
            this.DirectoryButton.Text = "Справочники";
            this.DirectoryButton.UseVisualStyleBackColor = true;
            this.DirectoryButton.Click += new System.EventHandler(this.Directory_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DirectoryButton);
            this.Controls.Add(this.DepartmentButton);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DepartmentButton;
        private System.Windows.Forms.Button DirectoryButton;
    }
}