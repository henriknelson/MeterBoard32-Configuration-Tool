using MeterBoard32.Classes;
using System;
using System.Windows.Forms;

namespace MeterBoard32.Forms
{
    public partial class DataRecordForm : Form
    {

        // Represents the data record we are currently working with
        private DataRecord currentDataRecord;
        public DataRecord resultRecord { get; set; }

        /// <summary>
        /// Constructor used when user wants to create a new data record
        /// </summary>
        public DataRecordForm()
        {
            InitializeComponent();
            currentDataRecord = new DataRecord();
            currentDataRecord.SetFunction(Function.Instantaneous);
            currentDataRecord.SetDataType(DataType._No_data);
        }

        /// <summary>
        /// Constructor used when user wants to modify an existing data record
        /// </summary>
        /// <param name="dataRecord">The data record to modify</param>
        public DataRecordForm(ref DataRecord dataRecord)
        {
            InitializeComponent();
            currentDataRecord = dataRecord;
        }

        private void DataRecordForm_Load(object sender, EventArgs e)
        {
            // Set up the current data records DIB field
            txtStorageNumber.Text = currentDataRecord.GetStorageNumber().ToString();
            txtTariff.Text = currentDataRecord.GetTariff().ToString();
            cmbBoxFunction.DataSource = Enum.GetValues(typeof(Function));
            cmbBoxFunction.SelectedItem = currentDataRecord.GetFunction();
            txtSubunit.Text = currentDataRecord.GetUnit().ToString();
            cmbBoxDataType.DataSource = Enum.GetValues(typeof(DataType));
            cmbBoxDataType.SelectedItem = currentDataRecord.GetDataType();

            // Set up the current data records VIB field

            // Get current VIF
            cmbBoxValueType.DataSource = VIFTableRecord.VifVariableTable;
            if (currentDataRecord.GetVIF() != null)
                cmbBoxValueType.SelectedItem = this.currentDataRecord.GetVIF();

            // In case of VIF 0xFB, GET VIFE
            cmbBoxExtension.DataSource = VifeFbTableRecord.VifeFbTable;
            if (currentDataRecord.GetVIFE_FB() != null)
            {
                cmbBoxExtension.Enabled = true;
                cmbBoxExtension.SelectedItem = currentDataRecord.GetVIFE_FB();
            }

            // In case of orthogonal VIF, get it
            cmbBoxOrthogonal.DataSource = VifeOrthogonalTableRecord.VifeOrthogonalTable;
            if (currentDataRecord.GetVIFE_O() != null)
                cmbBoxOrthogonal.SelectedItem = currentDataRecord.GetVIFE_O();

            // Get encoded data in HEX string format
            txtBoxData.Text = currentDataRecord.GetDataString();

        }

        private void cmbBoxValueType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VIFTableRecord selectedRecord = (VIFTableRecord)cmbBoxValueType.SelectedItem;
            if(selectedRecord.VIF.Equals(0xFB))
                cmbBoxExtension.DataSource = VifeFbTableRecord.VifeFbTable;
            else if (selectedRecord.VIF.Equals(0xFD))
                cmbBoxExtension.DataSource = VifeFdTableRecord.VifeFdTable;
            else
                return;
            cmbBoxExtension.Enabled = true;
        }

        private void btnSaveMeter_Click(object sender, EventArgs e)
        {
            currentDataRecord.SetDataType((DataType)cmbBoxDataType.SelectedItem);
            currentDataRecord.SetStorageNumber(Convert.ToInt64(txtStorageNumber.Text));
            currentDataRecord.SetTariff(Convert.ToInt32(txtTariff.Text));
            currentDataRecord.SetFunction((Function)cmbBoxFunction.SelectedItem);
            currentDataRecord.SetUnit(Convert.ToInt32(txtSubunit.Text));

            currentDataRecord.SetVIF((VIFTableRecord)cmbBoxValueType.SelectedItem);

            if (cmbBoxExtension.Enabled)
                currentDataRecord.SetVIFE_FB((VifeFbTableRecord)cmbBoxExtension.SelectedItem);

            currentDataRecord.SetVIFE_O((VifeOrthogonalTableRecord)cmbBoxOrthogonal.SelectedItem);

            currentDataRecord.SetData(txtBoxData.Text);

            currentDataRecord.encode();
            resultRecord = currentDataRecord;
            Close();
        }

        private void btnCancelMeter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
