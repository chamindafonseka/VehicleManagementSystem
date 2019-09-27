using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagementSystem
{
    public partial class FillingStation : Form
    {
        public FillingStation()
        {
            InitializeComponent();
        }

        private void FillingStation_Load(object sender, EventArgs e)
        {
            dgvFillingStation.AllowUserToAddRows = false;
            dgvFillingStation.ClearSelection();

        }
    }
}
