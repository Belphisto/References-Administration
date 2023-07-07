using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace References_Administration
{
    public partial class EventsForm : Form
    {
        public EventsForm()
        {
            InitializeComponent();
            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "dd.MMMM.yyyy HH:mm:ss";
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "dd.MMMM.yyyy HH:mm:ss";
            panelCreateEvent.Visible = false;
        }

        private void buttonCreateEvent_Click(object sender, EventArgs e)
        {
            panelCreateEvent.Visible = true;
        }

        private void buttonCancelEvent_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            panelCreateEvent.Visible = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }
    }
}
