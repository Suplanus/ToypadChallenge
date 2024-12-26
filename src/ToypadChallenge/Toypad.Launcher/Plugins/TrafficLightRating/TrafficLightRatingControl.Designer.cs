namespace Toypad.Launcher.Plugins.TrafficLightRating
{
    partial class TrafficLightRatingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayout = new TableLayoutPanel();
            lblRed = new Label();
            lblAmber = new Label();
            lblGreen = new Label();
            pnlRed = new Panel();
            pnlAmber = new Panel();
            pnlGreen = new Panel();
            grpConfig = new GroupBox();
            checkUseAmber = new CheckBox();
            btnReset = new Button();
            tableLayout.SuspendLayout();
            grpConfig.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 7;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayout.Controls.Add(lblRed, 1, 3);
            tableLayout.Controls.Add(lblAmber, 3, 3);
            tableLayout.Controls.Add(lblGreen, 5, 3);
            tableLayout.Controls.Add(pnlRed, 1, 1);
            tableLayout.Controls.Add(pnlAmber, 3, 1);
            tableLayout.Controls.Add(pnlGreen, 5, 1);
            tableLayout.Controls.Add(grpConfig, 1, 5);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(0, 0);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 7;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.Size = new Size(479, 350);
            tableLayout.TabIndex = 0;
            // 
            // lblRed
            // 
            lblRed.AutoSize = true;
            lblRed.Dock = DockStyle.Fill;
            lblRed.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblRed.ForeColor = Color.Red;
            lblRed.Location = new Point(23, 214);
            lblRed.Name = "lblRed";
            lblRed.Size = new Size(136, 30);
            lblRed.TabIndex = 1;
            lblRed.Text = "0";
            lblRed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAmber
            // 
            lblAmber.AutoSize = true;
            lblAmber.Dock = DockStyle.Fill;
            lblAmber.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblAmber.ForeColor = Color.Orange;
            lblAmber.Location = new Point(170, 214);
            lblAmber.Name = "lblAmber";
            lblAmber.Size = new Size(136, 30);
            lblAmber.TabIndex = 2;
            lblAmber.Text = "0";
            lblAmber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGreen
            // 
            lblGreen.AutoSize = true;
            lblGreen.Dock = DockStyle.Fill;
            lblGreen.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblGreen.ForeColor = Color.Green;
            lblGreen.Location = new Point(317, 214);
            lblGreen.Name = "lblGreen";
            lblGreen.Size = new Size(136, 30);
            lblGreen.TabIndex = 3;
            lblGreen.Text = "0";
            lblGreen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRed
            // 
            pnlRed.BackColor = Color.Red;
            pnlRed.Dock = DockStyle.Bottom;
            pnlRed.Location = new Point(23, 191);
            pnlRed.Name = "pnlRed";
            pnlRed.Size = new Size(136, 0);
            pnlRed.TabIndex = 4;
            // 
            // pnlAmber
            // 
            pnlAmber.BackColor = Color.Orange;
            pnlAmber.Dock = DockStyle.Bottom;
            pnlAmber.Location = new Point(170, 191);
            pnlAmber.Name = "pnlAmber";
            pnlAmber.Size = new Size(136, 0);
            pnlAmber.TabIndex = 5;
            // 
            // pnlGreen
            // 
            pnlGreen.BackColor = Color.Green;
            pnlGreen.Dock = DockStyle.Bottom;
            pnlGreen.Location = new Point(317, 191);
            pnlGreen.Name = "pnlGreen";
            pnlGreen.Size = new Size(136, 0);
            pnlGreen.TabIndex = 6;
            // 
            // grpConfig
            // 
            tableLayout.SetColumnSpan(grpConfig, 5);
            grpConfig.Controls.Add(checkUseAmber);
            grpConfig.Controls.Add(btnReset);
            grpConfig.Dock = DockStyle.Fill;
            grpConfig.Location = new Point(23, 267);
            grpConfig.Name = "grpConfig";
            grpConfig.Size = new Size(430, 60);
            grpConfig.TabIndex = 8;
            grpConfig.TabStop = false;
            // 
            // checkUseAmber
            // 
            checkUseAmber.AutoSize = true;
            checkUseAmber.Location = new Point(147, 26);
            checkUseAmber.Name = "checkUseAmber";
            checkUseAmber.Size = new Size(82, 19);
            checkUseAmber.TabIndex = 0;
            checkUseAmber.Text = "Use amber";
            checkUseAmber.UseVisualStyleBackColor = true;
            checkUseAmber.CheckedChanged += CheckUseAmber_CheckedChanged;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(6, 22);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(110, 23);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset statistic";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // TrafficLightRatingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayout);
            Name = "TrafficLightRatingControl";
            Size = new Size(479, 350);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            grpConfig.ResumeLayout(false);
            grpConfig.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayout;
        private CheckBox checkUseAmber;
        private Label lblRed;
        private Label lblAmber;
        private Label lblGreen;
        private Panel pnlRed;
        private Panel pnlAmber;
        private Panel pnlGreen;
        private Button btnReset;
        private GroupBox grpConfig;
    }
}
