
namespace References_Administration
{
    partial class EventsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCunfirmEvent = new System.Windows.Forms.Button();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.buttonCreateEvent = new System.Windows.Forms.Button();
            this.buttonCancelEvent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EventInfo = new System.Windows.Forms.Label();
            this.panelCreateEvent = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelCreateEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(524, 571);
            this.dataGridView1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(566, 435);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 86);
            this.textBox1.TabIndex = 6;
            // 
            // buttonCunfirmEvent
            // 
            this.buttonCunfirmEvent.Location = new System.Drawing.Point(587, 566);
            this.buttonCunfirmEvent.Name = "buttonCunfirmEvent";
            this.buttonCunfirmEvent.Size = new System.Drawing.Size(164, 33);
            this.buttonCunfirmEvent.TabIndex = 9;
            this.buttonCunfirmEvent.Text = "Подтвердить мероприятие";
            this.buttonCunfirmEvent.UseVisualStyleBackColor = true;
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(587, 28);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 2;
            // 
            // buttonCreateEvent
            // 
            this.buttonCreateEvent.Location = new System.Drawing.Point(587, 202);
            this.buttonCreateEvent.Name = "buttonCreateEvent";
            this.buttonCreateEvent.Size = new System.Drawing.Size(164, 33);
            this.buttonCreateEvent.TabIndex = 5;
            this.buttonCreateEvent.Text = "Создать мероприятие";
            this.buttonCreateEvent.UseVisualStyleBackColor = true;
            this.buttonCreateEvent.Click += new System.EventHandler(this.buttonCreateEvent_Click);
            // 
            // buttonCancelEvent
            // 
            this.buttonCancelEvent.Location = new System.Drawing.Point(587, 527);
            this.buttonCancelEvent.Name = "buttonCancelEvent";
            this.buttonCancelEvent.Size = new System.Drawing.Size(164, 33);
            this.buttonCancelEvent.TabIndex = 7;
            this.buttonCancelEvent.Text = "Отменить мероприятие";
            this.buttonCancelEvent.UseVisualStyleBackColor = true;
            this.buttonCancelEvent.Click += new System.EventHandler(this.buttonCancelEvent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(628, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Комментарий";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Выбрано мероприятие:";
            // 
            // EventInfo
            // 
            this.EventInfo.AutoSize = true;
            this.EventInfo.Location = new System.Drawing.Point(562, 281);
            this.EventInfo.Name = "EventInfo";
            this.EventInfo.Size = new System.Drawing.Size(0, 13);
            this.EventInfo.TabIndex = 11;
            // 
            // panelCreateEvent
            // 
            this.panelCreateEvent.Controls.Add(this.checkedListBox1);
            this.panelCreateEvent.Controls.Add(this.label7);
            this.panelCreateEvent.Controls.Add(this.buttonCancel);
            this.panelCreateEvent.Controls.Add(this.buttonOK);
            this.panelCreateEvent.Controls.Add(this.dateTimePickerEndTime);
            this.panelCreateEvent.Controls.Add(this.dateTimePickerStartTime);
            this.panelCreateEvent.Controls.Add(this.label6);
            this.panelCreateEvent.Controls.Add(this.label5);
            this.panelCreateEvent.Controls.Add(this.comboBox1);
            this.panelCreateEvent.Controls.Add(this.label4);
            this.panelCreateEvent.Controls.Add(this.textBoxNote);
            this.panelCreateEvent.Controls.Add(this.label3);
            this.panelCreateEvent.Location = new System.Drawing.Point(12, 110);
            this.panelCreateEvent.Name = "panelCreateEvent";
            this.panelCreateEvent.Size = new System.Drawing.Size(760, 423);
            this.panelCreateEvent.TabIndex = 12;
            this.panelCreateEvent.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Заметка";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(35, 41);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(631, 20);
            this.textBoxNote.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Совещательный зал";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(35, 96);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(631, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата и время начала мероприятия";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Дата и время завершения мероприятия";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(65, 317);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerStartTime.TabIndex = 8;
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(431, 317);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerEndTime.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(83, 367);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(154, 30);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "Создать";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(454, 367);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(154, 30);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Выбрать требуемое оборудование";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(35, 156);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(631, 94);
            this.checkedListBox1.TabIndex = 13;
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.panelCreateEvent);
            this.Controls.Add(this.EventInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCunfirmEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelEvent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCreateEvent);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.monthCalendar3);
            this.Name = "EventsForm";
            this.Text = "EventsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelCreateEvent.ResumeLayout(false);
            this.panelCreateEvent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCunfirmEvent;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.Button buttonCreateEvent;
        private System.Windows.Forms.Button buttonCancelEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label EventInfo;
        private System.Windows.Forms.Panel panelCreateEvent;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}