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
            components = new System.ComponentModel.Container();
            txtTitle = new Label();
            lblAPI = new Label();
            txtAPI = new TextBox();
            btnExecute = new Button();
            SystemStatus = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            cmbAction = new ComboBox();
            aPIAccessBindingSource = new BindingSource(components);
            tbResults = new TabPage();
            txtResults = new TextBox();
            tbBody = new TabPage();
            txtBody = new TextBox();
            tBodyResults = new TabControl();
            SystemStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)aPIAccessBindingSource).BeginInit();
            tbResults.SuspendLayout();
            tbBody.SuspendLayout();
            tBodyResults.SuspendLayout();
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
            // aPIAccessBindingSource
            // 
            aPIAccessBindingSource.DataSource = typeof(PostManCloneLibrary.APIAccess);
            // 
            // tbResults
            // 
            tbResults.Controls.Add(txtResults);
            tbResults.Location = new Point(4, 39);
            tbResults.Name = "tbResults";
            tbResults.Padding = new Padding(3);
            tbResults.Size = new Size(1163, 577);
            tbResults.TabIndex = 1;
            tbResults.Text = "Results";
            tbResults.UseVisualStyleBackColor = true;
            // 
            // txtResults
            // 
            txtResults.Location = new Point(7, 3);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(1150, 568);
            txtResults.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)aPIAccessBindingSource).EndInit();
            tbResults.ResumeLayout(false);
            tbResults.PerformLayout();
            tbBody.ResumeLayout(false);
            tbBody.PerformLayout();
            tBodyResults.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtTitle;
        private Label lblAPI;
        private TextBox txtAPI;
        private Button btnExecute;
        private StatusStrip SystemStatus;
        private ToolStripStatusLabel lblStatus;
        private ComboBox cmbAction;
        private BindingSource aPIAccessBindingSource;
        private TabPage tbResults;
        private TextBox txtResults;
        private TabPage tbBody;
        private TextBox txtBody;
        private TabControl tBodyResults;
    }
}
