namespace rsoi_lab1
{
    partial class AutForm
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // webBrowser
            this.webBrowser.AccessibleName = "";
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1020, 620);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // AutForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.Controls.Add(this.webBrowser);
            this.Margin = new System.Windows.Forms.Padding(40);
            this.Name = "AutForm";
            this.Text = "AppForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser;
       
    }
}

