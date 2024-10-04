using log4net;
using PostManCloneLibrary;


namespace PostmanCloneUI
{
    public partial class frmMain : Form
    {
        private readonly ILog _logger;
        private static HttpClient _client = new HttpClient();
        private readonly IAPIAccess apiAccess;
        public frmMain(ILog logger)
        {
            InitializeComponent();
            _logger = logger;
            apiAccess = new APIAccess(_client, _logger);

            cmbAction.SelectedItem = "GET";
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Calling API";
            string address = txtAPI.Text;
            string body = txtBody.Text;
            string results = "";

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
                JSONValidator jSONValidator = new();
                if (action != HttpAction.GET && action != HttpAction.DELETE)
                {
                    jSONValidator.ValidateJSON(body);
                    return;
                }
                tBodyResults.SelectedTab = tbResults;
                tbResults.Focus();
                try
                {
                    results = await apiAccess.CallAPI(address, _logger, body, action);
                    jSONValidator = new();
                    jSONValidator.ValidateJSON(results);
                    results = JsonFormatter.FormatJson(results);
                    LogDB logDB = new LogDB();
                    foreach (var result in results)
                    {
                        _logger.Info(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Text = $"Error Occured {ex.Message}");
                }
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
