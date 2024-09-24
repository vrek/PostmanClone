using PostManCloneLibrary;


namespace PostmanCloneUI
{
    public partial class frmMain : Form
    {
        private readonly IAPIAccess apiAccess = new APIAccess();

        string results = "";
        public frmMain()
        {
            InitializeComponent();

            cmbAction.SelectedItem = "GET";
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Calling API";
            string address = txtAPI.Text;
            string body = txtBody.Text;

            if (apiAccess.IsValidUrl(address) != true)
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
                if (action != HttpAction.GET && action != HttpAction.DELETE)
                {
                    JSONValidator jSONValidator = new();
                    jSONValidator.ValidateJSON(body);
                }
                tBodyResults.SelectedTab = tbResults;
                tbResults.Focus();
                results = await apiAccess.CallAPI(address, body, action);
                txtResults.Text = results;
                lblStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                SystemStatus.BackColor = Color.Red;
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = $"Error {ex.Message}";
            }

        }
    }
}
