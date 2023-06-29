
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
            this.EditButton.Location = new System.Drawing.Point(649, 96);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(122, 49);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Редактировать подразделение";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddDepartmentButton
            // 
            this.AddDepartmentButton.Location = new System.Drawing.Point(649, 21);
            this.AddDepartmentButton.Name = "AddDepartmentButton";
            this.AddDepartmentButton.Size = new System.Drawing.Size(122, 49);
            this.AddDepartmentButton.TabIndex = 2;
            this.AddDepartmentButton.Text = "Добавить подразделение";
            this.AddDepartmentButton.UseVisualStyleBackColor = true;
            this.AddDepartmentButton.Click += new System.EventHandler(this.AddDepartmentButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(649, 168);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(122, 48);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Удалить подразделение";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}