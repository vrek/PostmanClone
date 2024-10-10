using log4net;
using PostManCloneLibrary;


namespace PostmanCloneUI
{
    public partial class frmMain : Form
    {
        private readonly ILog _logger;
        private static HttpClient _client = new HttpClient();
        private readonly IAPIAccess apiAccess;
        private ILogDB _logDB;

        public frmMain(ILog logger, ILogDB logDB)
        {
            InitializeComponent();
            _logger = logger;
            _logDB = logDB;
            apiAccess = new APIAccess(_client);

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
                    var resultsForDB = JsonParser.ParseJsonString(results);
                    _logDB.InsertResults(resultsForDB);
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
