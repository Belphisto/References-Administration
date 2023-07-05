
namespace References_Administration
{
    partial class ClientsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEditButton = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreateRole = new System.Windows.Forms.Button();
            this.buttonDeleteRole = new System.Windows.Forms.Button();
            this.buttonEditRole = new System.Windows.Forms.Button();
            this.buttonAddUserRole = new System.Windows.Forms.Button();
            this.checkedListBoxDeletedRoles = new System.Windows.Forms.CheckedListBox();
            this.comboBoxEditRole = new System.Windows.Forms.ComboBox();
            this.textBoxNewRole = new System.Windows.Forms.TextBox();
            this.checkedListBoxAddingRoles = new System.Windows.Forms.CheckedListBox();
            this.buttonDeleteUserRole = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(12, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(637, 462);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripEditButton});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(800, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripEditButton
            // 
            this.toolStripEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripEditButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditButton.Image")));
            this.toolStripEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditButton.Name = "toolStripEditButton";
            this.toolStripEditButton.Size = new System.Drawing.Size(91, 22);
            this.toolStripEditButton.Text = "Редактировать";
            this.toolStripEditButton.Click += new System.EventHandler(this.toolStripEditButton_Click);
            // 
            // buttonCreateRole
            // 
            this.buttonCreateRole.Location = new System.Drawing.Point(656, 151);
            this.buttonCreateRole.Name = "buttonCreateRole";
            this.buttonCreateRole.Size = new System.Drawing.Size(133, 29);
            this.buttonCreateRole.TabIndex = 2;
            this.buttonCreateRole.Text = "Создать роль";
            this.buttonCreateRole.UseVisualStyleBackColor = true;
            this.buttonCreateRole.Click += new System.EventHandler(this.buttonCreateRole_Click);
            // 
            // buttonDeleteRole
            // 
            this.buttonDeleteRole.Location = new System.Drawing.Point(655, 28);
            this.buttonDeleteRole.Name = "buttonDeleteRole";
            this.buttonDeleteRole.Size = new System.Drawing.Size(133, 29);
            this.buttonDeleteRole.TabIndex = 3;
            this.buttonDeleteRole.Text = "Удалить роль";
            this.buttonDeleteRole.UseVisualStyleBackColor = true;
            this.buttonDeleteRole.Click += new System.EventHandler(this.buttonDeleteRole_Click);
            // 
            // buttonEditRole
            // 
            this.buttonEditRole.Location = new System.Drawing.Point(655, 90);
            this.buttonEditRole.Name = "buttonEditRole";
            this.buttonEditRole.Size = new System.Drawing.Size(133, 29);
            this.buttonEditRole.TabIndex = 4;
            this.buttonEditRole.Text = "Редактировать роль";
            this.buttonEditRole.UseVisualStyleBackColor = true;
            this.buttonEditRole.Click += new System.EventHandler(this.buttonEditRole_Click);
            // 
            // buttonAddUserRole
            // 
            this.buttonAddUserRole.Location = new System.Drawing.Point(656, 348);
            this.buttonAddUserRole.Name = "buttonAddUserRole";
            this.buttonAddUserRole.Size = new System.Drawing.Size(135, 48);
            this.buttonAddUserRole.TabIndex = 5;
            this.buttonAddUserRole.Text = "Добавить роли пользователю";
            this.buttonAddUserRole.UseVisualStyleBackColor = true;
            this.buttonAddUserRole.Click += new System.EventHandler(this.buttonAddUserRole_Click);
            // 
            // checkedListBoxDeletedRoles
            // 
            this.checkedListBoxDeletedRoles.FormattingEnabled = true;
            this.checkedListBoxDeletedRoles.Location = new System.Drawing.Point(655, 278);
            this.checkedListBoxDeletedRoles.Name = "checkedListBoxDeletedRoles";
            this.checkedListBoxDeletedRoles.Size = new System.Drawing.Size(136, 64);
            this.checkedListBoxDeletedRoles.TabIndex = 6;
            // 
            // comboBoxEditRole
            // 
            this.comboBoxEditRole.FormattingEnabled = true;
            this.comboBoxEditRole.Location = new System.Drawing.Point(656, 63);
            this.comboBoxEditRole.Name = "comboBoxEditRole";
            this.comboBoxEditRole.Size = new System.Drawing.Size(133, 21);
            this.comboBoxEditRole.TabIndex = 8;
            // 
            // textBoxNewRole
            // 
            this.textBoxNewRole.Location = new System.Drawing.Point(656, 125);
            this.textBoxNewRole.Name = "textBoxNewRole";
            this.textBoxNewRole.Size = new System.Drawing.Size(133, 20);
            this.textBoxNewRole.TabIndex = 9;
            // 
            // checkedListBoxAddingRoles
            // 
            this.checkedListBoxAddingRoles.FormattingEnabled = true;
            this.checkedListBoxAddingRoles.Location = new System.Drawing.Point(655, 402);
            this.checkedListBoxAddingRoles.Name = "checkedListBoxAddingRoles";
            this.checkedListBoxAddingRoles.Size = new System.Drawing.Size(136, 64);
            this.checkedListBoxAddingRoles.TabIndex = 10;
            // 
            // buttonDeleteUserRole
            // 
            this.buttonDeleteUserRole.Location = new System.Drawing.Point(656, 224);
            this.buttonDeleteUserRole.Name = "buttonDeleteUserRole";
            this.buttonDeleteUserRole.Size = new System.Drawing.Size(135, 48);
            this.buttonDeleteUserRole.TabIndex = 11;
            this.buttonDeleteUserRole.Text = "Удалить роли пользователя";
            this.buttonDeleteUserRole.UseVisualStyleBackColor = true;
            this.buttonDeleteUserRole.Click += new System.EventHandler(this.buttonDeleteUserRole_Click);
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.buttonDeleteUserRole);
            this.Controls.Add(this.checkedListBoxAddingRoles);
            this.Controls.Add(this.textBoxNewRole);
            this.Controls.Add(this.comboBoxEditRole);
            this.Controls.Add(this.checkedListBoxDeletedRoles);
            this.Controls.Add(this.buttonAddUserRole);
            this.Controls.Add(this.buttonEditRole);
            this.Controls.Add(this.buttonDeleteRole);
            this.Controls.Add(this.buttonCreateRole);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ClientsForm";
            this.Text = "ClientsForm";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton toolStripEditButton;
        private System.Windows.Forms.Button buttonCreateRole;
        private System.Windows.Forms.Button buttonDeleteRole;
        private System.Windows.Forms.Button buttonEditRole;
        private System.Windows.Forms.Button buttonAddUserRole;
        private System.Windows.Forms.CheckedListBox checkedListBoxDeletedRoles;
        private System.Windows.Forms.ComboBox comboBoxEditRole;
        private System.Windows.Forms.TextBox textBoxNewRole;
        private System.Windows.Forms.CheckedListBox checkedListBoxAddingRoles;
        private System.Windows.Forms.Button buttonDeleteUserRole;
    }
}