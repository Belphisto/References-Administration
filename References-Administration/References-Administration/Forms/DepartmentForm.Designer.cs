
namespace References_Administration
{
    partial class DepartmentForm
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddDepartmentButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.buttonCreateHoll = new System.Windows.Forms.Button();
            this.buttonDeleteHoll = new System.Windows.Forms.Button();
            this.buttonEditHoll = new System.Windows.Forms.Button();
            this.buttonShowDepartmentInHoll = new System.Windows.Forms.Button();
            this.comboBoxHolls = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 21);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(598, 417);
            this.treeView.TabIndex = 0;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(649, 21);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(122, 37);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Редактировать подразделение";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddDepartmentButton
            // 
            this.AddDepartmentButton.Location = new System.Drawing.Point(649, 64);
            this.AddDepartmentButton.Name = "AddDepartmentButton";
            this.AddDepartmentButton.Size = new System.Drawing.Size(122, 37);
            this.AddDepartmentButton.TabIndex = 2;
            this.AddDepartmentButton.Text = "Добавить подразделение";
            this.AddDepartmentButton.UseVisualStyleBackColor = true;
            this.AddDepartmentButton.Click += new System.EventHandler(this.AddDepartmentButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(649, 107);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(122, 37);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Удалить подразделение";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // buttonCreateHoll
            // 
            this.buttonCreateHoll.Location = new System.Drawing.Point(649, 187);
            this.buttonCreateHoll.Name = "buttonCreateHoll";
            this.buttonCreateHoll.Size = new System.Drawing.Size(122, 37);
            this.buttonCreateHoll.TabIndex = 4;
            this.buttonCreateHoll.Text = "Создать совещательный зал";
            this.buttonCreateHoll.UseVisualStyleBackColor = true;
            this.buttonCreateHoll.Click += new System.EventHandler(this.buttonCreateHoll_Click);
            // 
            // buttonDeleteHoll
            // 
            this.buttonDeleteHoll.Location = new System.Drawing.Point(649, 332);
            this.buttonDeleteHoll.Name = "buttonDeleteHoll";
            this.buttonDeleteHoll.Size = new System.Drawing.Size(122, 37);
            this.buttonDeleteHoll.TabIndex = 5;
            this.buttonDeleteHoll.Text = "Удалить совещательный зал";
            this.buttonDeleteHoll.UseVisualStyleBackColor = true;
            this.buttonDeleteHoll.Click += new System.EventHandler(this.buttonDeleteHoll_Click);
            // 
            // buttonEditHoll
            // 
            this.buttonEditHoll.Location = new System.Drawing.Point(649, 380);
            this.buttonEditHoll.Name = "buttonEditHoll";
            this.buttonEditHoll.Size = new System.Drawing.Size(122, 37);
            this.buttonEditHoll.TabIndex = 6;
            this.buttonEditHoll.Text = "Редактировать совещательный зал";
            this.buttonEditHoll.UseVisualStyleBackColor = true;
            this.buttonEditHoll.Click += new System.EventHandler(this.buttonEditHoll_Click);
            // 
            // buttonShowDepartmentInHoll
            // 
            this.buttonShowDepartmentInHoll.Location = new System.Drawing.Point(649, 260);
            this.buttonShowDepartmentInHoll.Name = "buttonShowDepartmentInHoll";
            this.buttonShowDepartmentInHoll.Size = new System.Drawing.Size(122, 66);
            this.buttonShowDepartmentInHoll.TabIndex = 7;
            this.buttonShowDepartmentInHoll.Text = "Показать подразделения совещательного зала";
            this.buttonShowDepartmentInHoll.UseVisualStyleBackColor = true;
            this.buttonShowDepartmentInHoll.Click += new System.EventHandler(this.buttonShowDepartmentInHoll_Click);
            // 
            // comboBoxHolls
            // 
            this.comboBoxHolls.FormattingEnabled = true;
            this.comboBoxHolls.Location = new System.Drawing.Point(649, 230);
            this.comboBoxHolls.Name = "comboBoxHolls";
            this.comboBoxHolls.Size = new System.Drawing.Size(122, 21);
            this.comboBoxHolls.TabIndex = 9;
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxHolls);
            this.Controls.Add(this.buttonShowDepartmentInHoll);
            this.Controls.Add(this.buttonEditHoll);
            this.Controls.Add(this.buttonDeleteHoll);
            this.Controls.Add(this.buttonCreateHoll);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddDepartmentButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.treeView);
            this.Name = "DepartmentForm";
            this.Text = "DepartmentForm";
            this.Load += new System.EventHandler(this.DepartmentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddDepartmentButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button buttonCreateHoll;
        private System.Windows.Forms.Button buttonDeleteHoll;
        private System.Windows.Forms.Button buttonEditHoll;
        private System.Windows.Forms.Button buttonShowDepartmentInHoll;
        private System.Windows.Forms.ComboBox comboBoxHolls;
    }
}