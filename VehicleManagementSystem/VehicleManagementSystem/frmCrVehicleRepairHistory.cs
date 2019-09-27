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
    public partial class frmCrVehicleRepairHistory : Form
    {
        public frmCrVehicleRepairHistory()
        {
            InitializeComponent();
        }

        private void frmCrVehicleRepairHistory_Load(object sender, EventArgs e)
        {
            //creating an object of Report Document class
            ReportDocument reportDocument = new ReportDocument();

            //Passing vehicle number...................................
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();
            //creating an object of ParameterFields class
            ParameterFields paramFields = new ParameterFields();
            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            //set the parameter field name
            paramField.Name = "VID";
            //set the parameter value
            paramDiscreteValue.Value = frmRepair.vid;  // int value comes from "frmRepair"
            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);
            // add the parameter in the ParameterFields object
            paramFields.Add(paramField);
            //set the parameterfield information in the crystal report

            
     


            crystalReportViewer1.ParameterFieldInfo = paramFields;


            //preparing root for preview
            reportDocument.Load(@"H:\MIT\Regain\Project VMS\Reports\CrVehicleRepairHistory.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            reportDocument.SetDatabaseLogon("reportuser", "890", @"CHAMINDA\MSSQLSERVER2", "VMS");

            reportDocument.Refresh();
        }
    }
}
