using BrightIdeasSoftware;
using MeterBoard32.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MeterBoard32.Forms
{
    public partial class MeterForm : Form
    {

        // Represents the meter we are currently working with
        private Meter currentMeter;
        public Meter resultMeter{ get; set; }

        TypedObjectListView<DataRecord> recordList;

        /// <summary>
        /// Constructor used when user wants to create a new virtual MBus meter
        /// </summary>
        public MeterForm()
        {
            SetupForm();
            currentMeter = new Meter("00000000", 1, MeterType.Other, "HCN");
        }


        /// <summary>
        /// Constructor used when user wants to modify an existing virtual MBus meter
        /// </summary>
        /// <param name="meter">The meter to modify</param>
        public MeterForm(ref Meter meter)
        {
            SetupForm();
            currentMeter = meter;
            updateGUI();
        }

        /// <summary>
        /// Initializes the form components
        /// </summary>
        private void SetupForm()
        {
            InitializeComponent();
            recordList = new TypedObjectListView<DataRecord>(dataRecordListView);
        }

        /// <summary>
        /// Called when the form has loaded.
        /// Used to set up the initial GUI state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeterForm_Load(object sender, EventArgs e)
        {
            // Set up data record list view
            recordList.GetColumn(0).AspectGetter = delegate (DataRecord x) { return x.GetDataType(); };
            recordList.GetColumn(1).AspectGetter = delegate (DataRecord x) { return x.GetStorageNumber(); };
            recordList.GetColumn(2).AspectGetter = delegate (DataRecord x) { return x.GetTariff(); };
            recordList.GetColumn(3).AspectGetter = delegate (DataRecord x) { return x.GetFunction(); };
            recordList.GetColumn(4).AspectGetter = delegate (DataRecord x) { return x.GetUnit(); };
            recordList.GetColumn(5).AspectGetter = delegate (DataRecord x) { return BitConverter.ToString(x.GetDIB()).Replace("-",""); };
            recordList.GetColumn(6).AspectGetter = delegate (DataRecord x) { return BitConverter.ToString(x.GetVIB()).Replace("-",""); };
            recordList.GetColumn(7).AspectGetter = delegate (DataRecord x) { return BitConverter.ToString(x.GetData()).Replace("-", ""); };
            recordList.GetColumn(8).AspectGetter = delegate (DataRecord x) { return "Delete"; };
            recordList.GetColumn(9).AspectGetter = delegate (DataRecord x) { return "Modify"; };
            recordList.ListView.ButtonClick += HandleListViewButtonClick;

            // Set up form caption
            Text = string.Format("Meter: {0}", currentMeter.MeterId);

            // Set up meter specific GUI components
            txtBoxMeterId.Text = currentMeter.MeterId;
            cmbBoxPrimaryAddress.Items.AddRange(Enumerable.Range(1, 250).Cast<object>().ToArray());
            cmbBoxPrimaryAddress.SelectedItem = currentMeter.PrimaryAddress;
            cmbBoxMeterType.DataSource = Enum.GetValues(typeof(MeterType));
            cmbBoxMeterType.SelectedItem = currentMeter.MeterType;
            txtBoxManufacturerId.Text = currentMeter.ManufacturerId;
        }

        /// <summary>
        /// Refreshes the listview with the last state of the data record list
        /// </summary>
        public void updateGUI()
        {
            recordList.ListView.SetObjects(currentMeter.dataRecords);
        }

        /// <summary>
        /// Used to handle a button click in the listview
        /// </summary>
        /// <param name="cellClickEvent">The event containing information about the button click</param>
        private void HandleListViewButtonClick(object sender2, CellClickEventArgs cellClickEvent)
        {
            DataRecord dataRecord = (DataRecord)cellClickEvent.Model;
            if (cellClickEvent.Column.Text.Equals("Delete"))
                DeleteDataRecord(ref dataRecord);
            else if (cellClickEvent.Column.Text.Equals("Modify"))
                ModifyDataRecord(ref dataRecord);
            dataRecordListView.RefreshObject(cellClickEvent.Model);
        }

        /// <summary>
        /// Used whenever the user wants to create a new data record
        /// </summary>
        private void CreateDataRecord()
        {
            DataRecordForm dataRecordForm = new DataRecordForm();
            if (dataRecordForm.ShowDialog(this).Equals(DialogResult.OK))
            {
                currentMeter.dataRecords.Add(dataRecordForm.resultRecord);
                updateGUI();
            }
        }

        /// <summary>
        /// Used whenever the user wants to modify a data record
        /// </summary>
        /// <param name="dataRecord">The data record to modify</param>
        private void ModifyDataRecord(ref DataRecord dataRecord)
        {
            DataRecordForm dataRecordForm = new DataRecordForm(ref dataRecord);
            if (dataRecordForm.ShowDialog(this).Equals(DialogResult.OK))
                dataRecordListView.UpdateObject(dataRecord);
        }

        /// <summary>
        /// Used whenever the user wants to delete a data record
        /// </summary>
        /// <param name="dataRecord">The data record to delete</param>
        private void DeleteDataRecord(ref DataRecord dataRecord)
        {
            currentMeter.dataRecords.Remove(dataRecord);
            dataRecordListView.RemoveObject(dataRecord);
        }

        /// <summary>
        /// Event handler for the 'Add data record' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDataRecord_Click(object sender, EventArgs e)
        {
            CreateDataRecord();
        }

        /// <summary>
        /// Event handler for the 'Save' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveMeter_Click(object sender, EventArgs e)
        {
            currentMeter.MeterId = txtBoxMeterId.Text;
            currentMeter.PrimaryAddress = (int) cmbBoxPrimaryAddress.SelectedItem;
            currentMeter.MeterType = (MeterType)cmbBoxMeterType.SelectedItem;
            currentMeter.ManufacturerId = txtBoxManufacturerId.Text;
            resultMeter = currentMeter;
            Close();
        }

        /// <summary>
        /// Event handler for the 'Cancel' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelMeter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
