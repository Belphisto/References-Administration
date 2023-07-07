
namespace References_Administration
{
    partial class EditHollForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxDepartments = new System.Windows.Forms.CheckedListBox();
            this.buttonDeleteDepartments = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBoxAddDepartments = new System.Windows.Forms.CheckedListBox();
            this.buttonAddDepartments = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEquipment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListBoxAddEquipments = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxDeleteEquipment = new System.Windows.Forms.CheckedListBox();
            this.buttonAddEquipments = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDeleteEquipment = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название совещательного зала";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(36, 59);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(518, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Подразделения, относящиеся к совещательному залу (не менее одного)";
            // 
            // checkedListBoxDepartments
            // 
            this.checkedListBoxDepartments.FormattingEnabled = true;
            this.checkedListBoxDepartments.Location = new System.Drawing.Point(36, 170);
            this.checkedListBoxDepartments.Name = "checkedListBoxDepartments";
            this.checkedListBoxDepartments.Size = new System.Drawing.Size(518, 79);
            this.checkedListBoxDepartments.TabIndex = 8;
            // 
            // buttonDeleteDepartments
            // 
            this.buttonDeleteDepartments.Location = new System.Drawing.Point(191, 255);
            this.buttonDeleteDepartments.Name = "buttonDeleteDepartments";
            this.buttonDeleteDepartments.Size = new System.Drawing.Size(363, 24);
            this.buttonDeleteDepartments.TabIndex = 9;
            this.buttonDeleteDepartments.Text = "Удалить выбранные подразделения из совещательного зала";
            this.buttonDeleteDepartments.UseVisualStyleBackColor = true;
            this.buttonDeleteDepartments.Click += new System.EventHandler(this.buttonDeleteDepartments_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Добавить выбранные подразделения к совещательному залу";
            // 
            // checkedListBoxAddDepartments
            // 
            this.checkedListBoxAddDepartments.FormattingEnabled = true;
            this.checkedListBoxAddDepartments.Location = new System.Drawing.Point(36, 309);
            this.checkedListBoxAddDepartments.Name = "checkedListBoxAddDepartments";
            this.checkedListBoxAddDepartments.Size = new System.Drawing.Size(518, 79);
            this.checkedListBoxAddDepartments.TabIndex = 11;
            // 
            // buttonAddDepartments
            // 
            this.buttonAddDepartments.Location = new System.Drawing.Point(191, 394);
            this.buttonAddDepartments.Name = "buttonAddDepartments";
            this.buttonAddDepartments.Size = new System.Drawing.Size(363, 24);
            this.buttonAddDepartments.TabIndex = 12;
            this.buttonAddDepartments.Text = "Добавить выбранные подразделения из совещательного зала";
            this.buttonAddDepartments.UseVisualStyleBackColor = true;
            this.buttonAddDepartments.Click += new System.EventHandler(this.buttonAddDepartments_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(570, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Введите наименование оборудования";
            // 
            // textBoxEquipment
            // 
            this.textBoxEquipment.Location = new System.Drawing.Point(573, 127);
            this.textBoxEquipment.Name = "textBoxEquipment";
            this.textBoxEquipment.Size = new System.Drawing.Size(213, 20);
            this.textBoxEquipment.TabIndex = 14;
            this.textBoxEquipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEquipment_KeyDown_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(571, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Выберите оборудование для добавления";
            // 
            // checkedListBoxAddEquipments
            // 
            this.checkedListBoxAddEquipments.FormattingEnabled = true;
            this.checkedListBoxAddEquipments.Location = new System.Drawing.Point(575, 170);
            this.checkedListBoxAddEquipments.Name = "checkedListBoxAddEquipments";
            this.checkedListBoxAddEquipments.Size = new System.Drawing.Size(213, 79);
            this.checkedListBoxAddEquipments.TabIndex = 16;
            // 
            // checkedListBoxDeleteEquipment
            // 
            this.checkedListBoxDeleteEquipment.FormattingEnabled = true;
            this.checkedListBoxDeleteEquipment.Location = new System.Drawing.Point(573, 309);
            this.checkedListBoxDeleteEquipment.Name = "checkedListBoxDeleteEquipment";
            this.checkedListBoxDeleteEquipment.Size = new System.Drawing.Size(213, 79);
            this.checkedListBoxDeleteEquipment.TabIndex = 17;
            // 
            // buttonAddEquipments
            // 
            this.buttonAddEquipments.Location = new System.Drawing.Point(575, 255);
            this.buttonAddEquipments.Name = "buttonAddEquipments";
            this.buttonAddEquipments.Size = new System.Drawing.Size(215, 24);
            this.buttonAddEquipments.TabIndex = 18;
            this.buttonAddEquipments.Text = "Добавить выбранное оборудование";
            this.buttonAddEquipments.UseVisualStyleBackColor = true;
            this.buttonAddEquipments.Click += new System.EventHandler(this.buttonAddEquipments_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(573, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Выберите оборудование для удаления";
            // 
            // buttonDeleteEquipment
            // 
            this.buttonDeleteEquipment.Location = new System.Drawing.Point(576, 394);
            this.buttonDeleteEquipment.Name = "buttonDeleteEquipment";
            this.buttonDeleteEquipment.Size = new System.Drawing.Size(215, 24);
            this.buttonDeleteEquipment.TabIndex = 20;
            this.buttonDeleteEquipment.Text = "Удалить выбранное оборудование";
            this.buttonDeleteEquipment.UseVisualStyleBackColor = true;
            this.buttonDeleteEquipment.Click += new System.EventHandler(this.buttonDeleteEquipment_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(202, 85);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(191, 24);
            this.buttonRename.TabIndex = 21;
            this.buttonRename.Text = "Переименовать";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // EditHollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.buttonDeleteEquipment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonAddEquipments);
            this.Controls.Add(this.checkedListBoxDeleteEquipment);
            this.Controls.Add(this.checkedListBoxAddEquipments);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEquipment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddDepartments);
            this.Controls.Add(this.checkedListBoxAddDepartments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDeleteDepartments);
            this.Controls.Add(this.checkedListBoxDepartments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "EditHollForm";
            this.Text = "EditHollForm";
            this.Load += new System.EventHandler(this.EditHollForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxDepartments;
        private System.Windows.Forms.Button buttonDeleteDepartments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBoxAddDepartments;
        private System.Windows.Forms.Button buttonAddDepartments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEquipment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListBoxAddEquipments;
        private System.Windows.Forms.CheckedListBox checkedListBoxDeleteEquipment;
        private System.Windows.Forms.Button buttonAddEquipments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDeleteEquipment;
        private System.Windows.Forms.Button buttonRename;
    }
}