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
            lblResults = new Label();
            txtResults = new TextBox();
            SystemStatus = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            SystemStatus.SuspendLayout();
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
            txtAPI.Location = new Point(76, 100);
            txtAPI.Name = "txtAPI";
            txtAPI.Size = new Size(990, 35);
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
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Location = new Point(21, 150);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(78, 30);
            lblResults.TabIndex = 0;
            lblResults.Text = "Results";
            // 
            // txtResults
            // 
            txtResults.BackColor = SystemColors.Info;
            txtResults.BorderStyle = BorderStyle.FixedSingle;
            txtResults.Location = new Point(21, 183);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Size = new Size(1180, 624);
            txtResults.TabIndex = 3;
            // 
            // SystemStatus
            // 
            SystemStatus.BackColor = SystemColors.WindowFrame;
            SystemStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SystemStatus.Items.AddRange(new ToolStripItem[] { lblStatus });
            SystemStatus.Location = new Point(0, 825);
            SystemStatus.Name = "SystemStatus";
            SystemStatus.Size = new Size(1216, 35);
            SystemStatus.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 30);
            lblStatus.Text = "Ready";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 860);
            Controls.Add(SystemStatus);
            Controls.Add(txtResults);
            Controls.Add(lblResults);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtTitle;
        private Label lblAPI;
        private TextBox txtAPI;
        private Button btnExecute;
        private Label lblResults;
        private TextBox txtResults;
        private StatusStrip SystemStatus;
        private ToolStripStatusLabel lblStatus;
    }
}
