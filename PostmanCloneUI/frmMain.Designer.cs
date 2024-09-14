namespace PostmanCloneUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new Label();
            lblAPI = new Label();
            txtAPI = new TextBox();
            btnExecute = new Button();
            txtResults = new TextBox();
            SystemStatus = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            cmbAction = new ComboBox();
            tBodyResults = new TabControl();
            tbBody = new TabPage();
            txtBody = new TextBox();
            tbResults = new TabPage();
            SystemStatus.SuspendLayout();
            tBodyResults.SuspendLayout();
            tbBody.SuspendLayout();
            tbResults.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(21, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(266, 47);
            txtTitle.TabIndex = 0;
            txtTitle.Text = "Postman Clone";
            // 
            // lblAPI
            // 
            lblAPI.AutoSize = true;
            lblAPI.Location = new Point(25, 100);
            lblAPI.Name = "lblAPI";
            lblAPI.Size = new Size(45, 30);
            lblAPI.TabIndex = 0;
            lblAPI.Text = "API";
            // 
            // txtAPI
            // 
            txtAPI.Location = new Point(250, 100);
            txtAPI.Name = "txtAPI";
            txtAPI.Size = new Size(829, 35);
            txtAPI.TabIndex = 1;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(1085, 101);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(116, 35);
            btnExecute.TabIndex = 2;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // txtResults
            // 
            txtResults.BackColor = SystemColors.Info;
            txtResults.BorderStyle = BorderStyle.FixedSingle;
            txtResults.Dock = DockStyle.Fill;
            txtResults.Location = new Point(3, 3);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Size = new Size(1157, 586);
            txtResults.TabIndex = 3;
            // 
            // SystemStatus
            // 
            SystemStatus.BackColor = SystemColors.ControlDarkDark;
            SystemStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SystemStatus.Items.AddRange(new ToolStripItem[] { lblStatus });
            SystemStatus.Location = new Point(0, 825);
            SystemStatus.Name = "SystemStatus";
            SystemStatus.Size = new Size(1216, 35);
            SystemStatus.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.ActiveLinkColor = Color.RebeccaPurple;
            lblStatus.BackColor = Color.Yellow;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 30);
            lblStatus.Text = "Ready";
            // 
            // cmbAction
            // 
            cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAction.FormattingEnabled = true;
            cmbAction.Items.AddRange(new object[] { "GET", "POST", "PATCH", "PUT", "DELETE" });
            cmbAction.Location = new Point(76, 100);
            cmbAction.Name = "cmbAction";
            cmbAction.Size = new Size(168, 38);
            cmbAction.TabIndex = 4;
            // 
            // tBodyResults
            // 
            tBodyResults.Controls.Add(tbBody);
            tBodyResults.Controls.Add(tbResults);
            tBodyResults.Location = new Point(30, 165);
            tBodyResults.Name = "tBodyResults";
            tBodyResults.SelectedIndex = 0;
            tBodyResults.Size = new Size(1171, 620);
            tBodyResults.TabIndex = 5;
            // 
            // tbBody
            // 
            tbBody.Controls.Add(txtBody);
            tbBody.Location = new Point(4, 39);
            tbBody.Name = "tbBody";
            tbBody.Padding = new Padding(3);
            tbBody.Size = new Size(1163, 577);
            tbBody.TabIndex = 0;
            tbBody.Text = "Body";
            tbBody.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            txtBody.Dock = DockStyle.Fill;
            txtBody.Location = new Point(3, 3);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(1157, 571);
            txtBody.TabIndex = 0;
            // 
            // tbResults
            // 
            tbResults.Controls.Add(txtResults);
            tbResults.Location = new Point(4, 24);
            tbResults.Name = "tbResults";
            tbResults.Padding = new Padding(3);
            tbResults.Size = new Size(1163, 592);
            tbResults.TabIndex = 1;
            tbResults.Text = "Results";
            tbResults.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 860);
            Controls.Add(tBodyResults);
            Controls.Add(cmbAction);
            Controls.Add(SystemStatus);
            Controls.Add(btnExecute);
            Controls.Add(txtAPI);
            Controls.Add(lblAPI);
            Controls.Add(txtTitle);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 6, 5, 6);
            Name = "frmMain";
            Text = "PostManClone";
            SystemStatus.ResumeLayout(false);
            SystemStatus.PerformLayout();
            tBodyResults.ResumeLayout(false);
            tbBody.ResumeLayout(false);
            tbBody.PerformLayout();
            tbResults.ResumeLayout(false);
            tbResults.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtTitle;
        private Label lblAPI;
        private TextBox txtAPI;
        private Button btnExecute;
        private TextBox txtResults;
        private StatusStrip SystemStatus;
        private ToolStripStatusLabel lblStatus;
        private ComboBox cmbAction;
        private TabControl tBodyResults;
        private TabPage tbBody;
        private TabPage tbResults;
        private TextBox txtBody;
    }
}
