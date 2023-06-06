namespace LocalFileSender.WinForms.Views
{
    partial class DownloadView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadView));
            DownloadProgressBar = new ProgressBar();
            SpeedLabel = new Label();
            FileNumberLabel = new Label();
            FileNameLabel = new Label();
            SuspendLayout();
            // 
            // DownloadProgressBar
            // 
            DownloadProgressBar.Location = new Point(24, 128);
            DownloadProgressBar.Margin = new Padding(15, 14, 15, 14);
            DownloadProgressBar.Name = "DownloadProgressBar";
            DownloadProgressBar.Size = new Size(674, 33);
            DownloadProgressBar.TabIndex = 0;
            // 
            // SpeedLabel
            // 
            SpeedLabel.AutoSize = true;
            SpeedLabel.Location = new Point(24, 15);
            SpeedLabel.Margin = new Padding(12, 6, 12, 6);
            SpeedLabel.MaximumSize = new Size(674, 23);
            SpeedLabel.Name = "SpeedLabel";
            SpeedLabel.Size = new Size(104, 23);
            SpeedLabel.TabIndex = 1;
            SpeedLabel.Text = "Speed: 0 B/s";
            SpeedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FileNumberLabel
            // 
            FileNumberLabel.AutoSize = true;
            FileNumberLabel.Location = new Point(24, 50);
            FileNumberLabel.Margin = new Padding(12, 6, 12, 6);
            FileNumberLabel.MaximumSize = new Size(674, 23);
            FileNumberLabel.Name = "FileNumberLabel";
            FileNumberLabel.Size = new Size(109, 23);
            FileNumberLabel.TabIndex = 2;
            FileNumberLabel.Text = "Progress: 0/0";
            FileNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FileNameLabel
            // 
            FileNameLabel.AutoSize = true;
            FileNameLabel.Location = new Point(24, 85);
            FileNameLabel.Margin = new Padding(12, 6, 12, 6);
            FileNameLabel.MaximumSize = new Size(674, 23);
            FileNameLabel.Name = "FileNameLabel";
            FileNameLabel.Size = new Size(45, 23);
            FileNameLabel.TabIndex = 3;
            FileNameLabel.Text = "File: ";
            FileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DownloadView
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 188);
            Controls.Add(FileNameLabel);
            Controls.Add(FileNumberLabel);
            Controls.Add(SpeedLabel);
            Controls.Add(DownloadProgressBar);
            Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DownloadView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Progress";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar DownloadProgressBar;
        private Label SpeedLabel;
        private Label FileNumberLabel;
        private Label FileNameLabel;
    }
}