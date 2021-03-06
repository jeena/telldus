using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeviceScheduler
{
    public partial class frmScheduleAddDevice : Form
    {
        public frmScheduleAddDevice()
        {
            Localization.ChangeLanguage();
            InitializeComponent();
            
        }
        

        private void frmScheduleAddDevice_Load(object sender, EventArgs e)
        {
            //Fill the combobox with Devices
            FillCombo();

            //Preselect device and action
            if (cboDevices.Items.Count > 0)
            {
                cboDevices.SelectedIndex = 0;
            }
            else
            {
                //"Inga enheter finns. L�gg f�rst till enheter genom att klicka p� \"configure unit(s)\"."
                MessageBox.Show(Localization.GetString("nounitsexists"), Localization.GetString("telldusscheduler"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (cboAction.Items.Count > 0)
            {
                cboAction.SelectedIndex = 0;
            }
        }

        private void FillCombo()
        {
            Program.DeviceHandler.Load();

            foreach (DeviceHandler.Device item in Program.DeviceHandler.Devices)
            {
                cboDevices.Items.Add(item);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        public DeviceHandler.Device SelectedDevice
        {
            get
            { return (DeviceHandler.Device)cboDevices.SelectedItem;}
        }

        public int SelectedDeviceAction
        {
            get
            { return cboAction.SelectedIndex;}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}