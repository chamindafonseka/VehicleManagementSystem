using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace VehicleManagementSystem
{
    public partial class frmCrAllocatedTeams : Form
    {
        public frmCrAllocatedTeams()
        {
            InitializeComponent();
        }

        private void frmCrAllocatedTeams_Load(object sender, EventArgs e)
        {
            //creating an object of Report Document class
            ReportDocument reportDocument = new ReportDocument();
            


            //preparing root for preview
            reportDocument.Load(@"H:\MIT\Regain\Project VMS\Reports\CrAllocatedTeams.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            reportDocument.SetDatabaseLogon("reportuser", "890", @"CHAMINDA\MSSQLSERVER2", "VMS");

            reportDocument.Refresh();
        }
    }
}
