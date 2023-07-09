
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCunfirmEvent = new System.Windows.Forms.Button();
            this.monthCalendar3 = new System.Windows.Forms.MonthCalendar();
            this.buttonCreateEvent = new System.Windows.Forms.Button();
            this.buttonCancelEvent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEventInfo = new System.Windows.Forms.Label();
            this.EventInfo = new System.Windows.Forms.Label();
            this.panelCreateEvent = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEventInDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelCreateEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.buttonCunfirmEvent.Click += new System.EventHandler(this.buttonCunfirmEvent_Click);
            // 
            // monthCalendar3
            // 
            this.monthCalendar3.Location = new System.Drawing.Point(587, 73);
            this.monthCalendar3.Name = "monthCalendar3";
            this.monthCalendar3.TabIndex = 2;
            this.monthCalendar3.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar3_DateSelected);
            // 
            // buttonCreateEvent
            // 
            this.buttonCreateEvent.Location = new System.Drawing.Point(587, 28);
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
            // labelEventInfo
            // 
            this.labelEventInfo.AutoSize = true;
            this.labelEventInfo.Location = new System.Drawing.Point(606, 271);
            this.labelEventInfo.Name = "labelEventInfo";
            this.labelEventInfo.Size = new System.Drawing.Size(125, 13);
            this.labelEventInfo.TabIndex = 10;
            this.labelEventInfo.Text = "Выбрано мероприятие:";
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
            this.panelCreateEvent.Location = new System.Drawing.Point(12, 381);
            this.panelCreateEvent.Name = "panelCreateEvent";
            this.panelCreateEvent.Size = new System.Drawing.Size(760, 587);
            this.panelCreateEvent.TabIndex = 12;
            this.panelCreateEvent.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(35, 229);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(631, 94);
            this.checkedListBox1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Выбрать требуемое оборудование";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(454, 440);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(154, 30);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(83, 440);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(154, 30);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "Создать";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(431, 390);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerEndTime.TabIndex = 9;
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(65, 390);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(219, 20);
            this.dateTimePickerStartTime.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Дата и время завершения мероприятия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата и время начала мероприятия";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(35, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(631, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Совещательный зал";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(35, 114);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(631, 20);
            this.textBoxNote.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Заметка";
            // 
            // comboBoxEventInDay
            // 
            this.comboBoxEventInDay.FormattingEnabled = true;
            this.comboBoxEventInDay.Location = new System.Drawing.Point(566, 247);
            this.comboBoxEventInDay.Name = "comboBoxEventInDay";
            this.comboBoxEventInDay.Size = new System.Drawing.Size(206, 21);
            this.comboBoxEventInDay.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Здесь будет информация обо всех мероприятиях на выбранный день";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(519, 518);
            this.dataGridView1.TabIndex = 15;
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelCreateEvent);
            this.Controls.Add(this.comboBoxEventInDay);
            this.Controls.Add(this.labelEventInfo);
            this.Controls.Add(this.EventInfo);
            this.Controls.Add(this.buttonCunfirmEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelEvent);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCreateEvent);
            this.Controls.Add(this.monthCalendar3);
            this.Name = "EventsForm";
            this.Text = "EventsForm";
            this.panelCreateEvent.ResumeLayout(false);
            this.panelCreateEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCunfirmEvent;
        private System.Windows.Forms.MonthCalendar monthCalendar3;
        private System.Windows.Forms.Button buttonCreateEvent;
        private System.Windows.Forms.Button buttonCancelEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEventInfo;
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
        private System.Windows.Forms.ComboBox comboBoxEventInDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}