
namespace References_Administration
{
    partial class CreateHollForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEquipment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBoxEquipments = new System.Windows.Forms.CheckedListBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название совещательного зала";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(53, 50);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(518, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Подразделения, относящиеся к совещательному залу (выбрать не менее одного)";
            // 
            // checkedListBoxDepartments
            // 
            this.checkedListBoxDepartments.FormattingEnabled = true;
            this.checkedListBoxDepartments.Location = new System.Drawing.Point(53, 113);
            this.checkedListBoxDepartments.Name = "checkedListBoxDepartments";
            this.checkedListBoxDepartments.Size = new System.Drawing.Size(518, 79);
            this.checkedListBoxDepartments.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Введите наименование оборудования";
            // 
            // textBoxEquipment
            // 
            this.textBoxEquipment.Location = new System.Drawing.Point(53, 227);
            this.textBoxEquipment.Name = "textBoxEquipment";
            this.textBoxEquipment.Size = new System.Drawing.Size(518, 20);
            this.textBoxEquipment.TabIndex = 9;
            this.textBoxEquipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEquipment_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Выберите доступное в совещательном зале оборудование";
            // 
            // checkedListBoxEquipments
            // 
            this.checkedListBoxEquipments.FormattingEnabled = true;
            this.checkedListBoxEquipments.Location = new System.Drawing.Point(53, 277);
            this.checkedListBoxEquipments.Name = "checkedListBoxEquipments";
            this.checkedListBoxEquipments.Size = new System.Drawing.Size(518, 94);
            this.checkedListBoxEquipments.TabIndex = 11;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(53, 395);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(120, 24);
            this.buttonCreate.TabIndex = 12;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(451, 395);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 24);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CreateHollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.checkedListBoxEquipments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEquipment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBoxDepartments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "CreateHollForm";
            this.Text = "CreateHollForm";
            this.Load += new System.EventHandler(this.CreateHollForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxDepartments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEquipment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBoxEquipments;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
    }
}