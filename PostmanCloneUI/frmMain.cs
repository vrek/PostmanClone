using PostManCloneLibrary;


namespace PostmanCloneUI
{
    public partial class frmMain : Form
    {
        private readonly IAPIAccess apiAccess = new APIAccess();
        public frmMain()
        {
            InitializeComponent();
            cmbAction.SelectedItem = "GET";
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Calling API";

            if (apiAccess.IsValidUrl(txtAPI.Text) != true)
            {
                lblStatus.Text = "URL Invalid";
                SystemStatus.BackColor = Color.Red;
                lblStatus.ForeColor = Color.Black;
                return;
            }

            HttpAction action;
            if (Enum.TryParse(cmbAction.SelectedItem!.ToString(), out action) == false)
            {
                lblStatus.Text = "Invalid HTTP Action";
                return;
            }

            try
            {
                tBodyResults.SelectedTab = tbResults;
                tbResults.Focus();
                txtResults.Text = await apiAccess.CallAPI(txtAPI.Text, txtBody.Text, action);
                lblStatus.Text = "Ready";
            }
            catch
            {
                lblStatus.Text = "Error";
            }

        }
    }
}
