using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemOrder
{
    public partial class Form1 : Form
    {
        string CopyMedication = "N";
        public string strcheck = "";
        public string orderNumber;
        public static DataTable dtList;
        public static DataRow drList;
        string isSelected = "N";
        public static int drugAddListFlag;
        public static string saveStatus;
        string Save_Status = "I";
        int Selected_Row = 0;

        public int iBatchSelectedCount = 0;
        public int iBatch_TotalItemCount = 0;
        public int iTotalI_Select_Count = 0;

        public string isFavourite = "N";
        public DataTable ldtGroupMedList;

        public Form1()
        {
            InitializeComponent();
            initializeDataTable();
        }

        private void initializeDataTable()
        {
            dtList = new DataTable();

            dtList.Columns.Add("VisitNo");
            dtList.Columns.Add("pMRN");
            dtList.Columns.Add("ProviderID");
            dtList.Columns.Add("ProviderName");
            dtList.Columns.Add("StockCode");
            dtList.Columns.Add("ItemName");
            dtList.Columns.Add("Dosage");
            dtList.Columns.Add("CustomFrequency");
            dtList.Columns.Add("UnitCode");
            dtList.Columns.Add("RxDate");
            dtList.Columns.Add("Rx_Qty");
            dtList.Columns.Add("CourseDuration");
            dtList.Columns.Add("Duration");
            dtList.Columns.Add("Duration_Type");
            dtList.Columns.Add("PatMedStatus");
            dtList.Columns.Add("OrderDate");
            dtList.Columns.Add("CreatedBy");
            dtList.Columns.Add("Phy_Comments");
            dtList.Columns.Add("ordstatus");
            dtList.Columns.Add("OrdType");
        }

        private void txtdoctorcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoctorname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            drList = dtList.NewRow();


            drList["ProviderID"] = txtdoctorcode.Text;
            drList["ProviderName"] = txtDoctorname.Text;
            drList["ItemName"] = txtItemName.Text;
            drList["StockCode"] = "7777";


            drList["UnitCode"] = "";

            drList["RxDate"] = dtpRxdate.Value.Date;
            drList["Rx_Qty"] = Convert.ToDecimal(txtrxqty.Text.ToString().Trim());


            if (txtDuration.Text.ToString().Trim() == "")
            {

                drList["Duration"] = 1;
            }
            else
            {
                drList["Duration"] = txtDuration.Text.ToString().Trim();
            }

            drList["RxDate"] = dtpRxdate.Value.Date;
            //drList["Duration_Type"] = cmbDurationType.SelectedValue.ToString().Trim();
            drList["Duration_Type"] = "Days";
            drList["PatMedStatus"] = "O";

            drList["OrderDate"] = DateTime.Now.Date;
            if (txtRemarks.Text.Trim().Equals(""))
            {
                drList["Phy_Comments"] = "";
            }
            else
            {

                drList["Phy_Comments"] = txtRemarks.Text.Trim();
            }

            drList["ordstatus"] = "P";
            drList["OrdType"] = "N";

            dtList.Rows.Add(drList);



            DataSet dsDrugList = new DataSet();
            dsDrugList.Tables.Add(dtList.Copy());
            dgvItemListOrder.AutoGenerateColumns = false;

            dgvItemListOrder.DataSource = dsDrugList.Tables[0];
        }
    }
}
