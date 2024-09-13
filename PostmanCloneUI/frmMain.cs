using PostManCloneLibrary;


namespace PostmanCloneUI
{
    public partial class frmMain : Form
    {
        private readonly IAPIAccess apiAccess = new APIAccess();
        public frmMain()
        {
            InitializeComponent();
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Calling API";
            lblResults.Text = "";

            if (apiAccess.IsValidUrl(txtAPI.Text) != true)
            {
                lblStatus.Text = "URL Invalid";
                SystemStatus.BackColor = Color.Red;
                lblStatus.ForeColor = Color.Black;
                return;
            }

            try
            {
                txtResults.Text = await apiAccess.CallAPI(txtAPI.Text);
                lblStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                lblResults.Text = ex.Message;
                lblStatus.Text = "Error";
            }

        }
    }
}
