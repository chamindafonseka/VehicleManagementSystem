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
    public partial class frmMileageDriver : Form
    {
        public frmMileageDriver()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
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
            paramField.Name = "Driver";
            //set the parameter value
            paramDiscreteValue.Value = frmRunningChart.drivername.Trim();

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);
            // add the parameter in the ParameterFields object
            paramFields.Add(paramField);
            //set the parameterfield information in the crystal report



            //////passing start date
            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
            paramField2.Name = "fromDate";
            paramDiscreteValue2.Value = frmRunningChart.fromDate;
            paramField2.CurrentValues.Add(paramDiscreteValue2);
            paramFields.Add(paramField2);

            ////passing end date
            ParameterField paramField3 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
            paramField3.Name = "toDate";
            paramDiscreteValue3.Value = frmRunningChart.toDate;
            paramField3.CurrentValues.Add(paramDiscreteValue3);
            paramFields.Add(paramField3);



            crystalReportViewer1.ParameterFieldInfo = paramFields;


            //preparing root for preview
            reportDocument.Load(@"H:\MIT\Regain\Project VMS\Reports\CrMileageDriver.rpt");
            crystalReportViewer1.ReportSource = reportDocument;
            reportDocument.SetDatabaseLogon("reportuser", "890", @"CHAMINDA\MSSQLSERVER2", "VMS");

            reportDocument.Refresh();
        }
    }
}
