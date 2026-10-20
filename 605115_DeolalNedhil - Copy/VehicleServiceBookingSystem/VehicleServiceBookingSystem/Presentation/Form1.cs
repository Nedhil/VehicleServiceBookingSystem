using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VehicleServiceBookingSystem.BuisnessLogic;

using VehicleServiceBookingSystem.DataAccess;

namespace VehicleServiceBookingSystem
{
    public partial class Form1 : Form
    {
        private DataHandler handler = new DataHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            try
            {
                dgvBookings.DataSource = handler.GetAllBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // When clicking a row in the grid, populate the textboxes
        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                txtBookingID.Text = row.Cells["BookingID"].Value.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtVehicleReg.Text = row.Cells["VehicleRegistration"].Value.ToString();
                cmbServiceType.Text = row.Cells["ServiceType"].Value.ToString();
                dtpBookingDate.Value = Convert.ToDateTime(row.Cells["BookingDate"].Value);
                txtCost.Text = row.Cells["Cost"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                decimal.TryParse(txtCost.Text, out decimal cost);

                ServiceBooking booking = new ServiceBooking
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    VehicleRegistration = txtVehicleReg.Text.Trim(),
                    ServiceType = cmbServiceType.Text.Trim(),
                    BookingDate = dtpBookingDate.Value,
                    Cost = cost
                };

                Validation.ValidateBooking(booking, true);
                handler.InsertBooking(booking.CustomerName, booking.VehicleRegistration, booking.ServiceType, booking.BookingDate, booking.Cost);

                MessageBox.Show("Booking added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBookingID.Text))
                {
                    MessageBox.Show("Please select a booking to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(txtBookingID.Text);
                decimal.TryParse(txtCost.Text, out decimal cost);

                ServiceBooking booking = new ServiceBooking
                {
                    BookingID = id,
                    CustomerName = txtCustomerName.Text.Trim(),
                    VehicleRegistration = txtVehicleReg.Text.Trim(),
                    ServiceType = cmbServiceType.Text.Trim(),
                    BookingDate = dtpBookingDate.Value,
                    Cost = cost
                };

                Validation.ValidateBooking(booking, false);
                handler.UpdateBooking(booking.BookingID, booking.CustomerName, booking.VehicleRegistration, booking.ServiceType, booking.BookingDate, booking.Cost);

                MessageBox.Show("Booking updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBookingID.Text))
                {
                    MessageBox.Show("Please select a booking to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(txtBookingID.Text);
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    handler.DeleteBooking(id);
                    MessageBox.Show("Booking deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtBookingID.Clear();
            txtCustomerName.Clear();
            txtVehicleReg.Clear();
            cmbServiceType.SelectedIndex = -1;
            dtpBookingDate.Value = DateTime.Today;
            txtCost.Clear();
        }
    }
}