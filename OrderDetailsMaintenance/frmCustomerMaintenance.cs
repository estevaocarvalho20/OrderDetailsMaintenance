namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        private OrderDetailsMaintenance.Models.DataLayer.NorthwindContext _context;

        // estevao Previatti
        public frmCustomerMaintenance()
        {
            InitializeComponent();
            _context = new OrderDetailsMaintenance.Models.DataLayer.NorthwindContext();
        }

        // estevao Previatti
        private void frmCustomerMaintenance_Load(object sender, EventArgs e)
        {

        }

        // estevao Previatti
        private void btnFind_Click(object sender, EventArgs e)
        {
            var id = txtCustomerId.Text?.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter a Customer ID.", "Missing ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                MessageBox.Show($"Customer '{id}' not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                txtContact.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtCountry.Text = string.Empty;
                return;
            }

           
            txtContact.Text = customer.ContactName ?? string.Empty;
            txtAddress.Text = customer.Address ?? string.Empty;
            txtCity.Text = customer.City ?? string.Empty;
            txtCountry.Text = customer.Country ?? string.Empty;
        }

        // estevao Previatti
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // estevao Previatti
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }

        // estevao Previatti
        private void btnSave_Click(object sender, EventArgs e)
        {
            var id = txtCustomerId.Text?.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please enter a Customer ID.", "Missing ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                MessageBox.Show($"Customer '{id}' not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            customer.ContactName = string.IsNullOrEmpty(txtContact.Text) ? null : txtContact.Text;
            customer.Address = string.IsNullOrEmpty(txtAddress.Text) ? null : txtAddress.Text;
            customer.City = string.IsNullOrEmpty(txtCity.Text) ? null : txtCity.Text;
            customer.Country = string.IsNullOrEmpty(txtCountry.Text) ? null : txtCountry.Text;

            
            _context.Customers.Update(customer);
            _context.SaveChanges();

            MessageBox.Show($"Customer '{id}' updated successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}