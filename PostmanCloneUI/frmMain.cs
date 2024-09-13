namespace PostmanCloneUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {

            //TODO : Validate API format

            try
            {
                lblStatus.Text = "Calling API";

                //TODO : replace with real API processing
                await Task.Delay(2000);

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
