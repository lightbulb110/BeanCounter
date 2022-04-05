using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmWebDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
		public WebBrowser wbWebDownload;

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
            this.wbWebDownload = new WebBrowser();
            base.SuspendLayout();
            this.wbWebDownload.Dock = DockStyle.Fill;
            this.wbWebDownload.Location = new Point(0, 0);
            this.wbWebDownload.MinimumSize = new Size(20, 20);
            this.wbWebDownload.Name = "wbWebDownload";
            this.wbWebDownload.Size = new Size(503, 402);
            this.wbWebDownload.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(503, 402);
            base.Controls.Add(this.wbWebDownload);
            base.Name = "FrmWebDownload";
            this.Text = "FrmWebDownload";
            base.ResumeLayout(false);
        }

        #endregion
    }
}