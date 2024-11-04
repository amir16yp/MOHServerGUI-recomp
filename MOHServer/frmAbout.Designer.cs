namespace MOHServer
{
    public partial class frmAbout : global::System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::MOHServer.frmAbout));
            this.pictBoxAbout = new global::System.Windows.Forms.PictureBox();
            this.lblAboutAppName = new global::System.Windows.Forms.Label();
            this.lblAboutCopyright = new global::System.Windows.Forms.Label();
            this.lblSubtitle = new global::System.Windows.Forms.Label();
            this.lblModCredit = new global::System.Windows.Forms.Label();
            base.SuspendLayout();
            this.pictBoxAbout.Image = (global::System.Drawing.Image)resourceManager.GetObject("pictBoxAbout.Image");
            this.pictBoxAbout.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
            this.pictBoxAbout.Location = new global::System.Drawing.Point(8, 8);
            this.pictBoxAbout.Name = "pictBoxAbout";
            this.pictBoxAbout.Size = new global::System.Drawing.Size(96, 96);
            this.pictBoxAbout.TabIndex = 0;
            this.pictBoxAbout.TabStop = false;
            this.lblAboutAppName.Font = new global::System.Drawing.Font("moh_14", 14.25f, global::System.Drawing.FontStyle.Bold);
            this.lblAboutAppName.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
            this.lblAboutAppName.Location = new global::System.Drawing.Point(120, 8);
            this.lblAboutAppName.Name = "lblAboutAppName";
            this.lblAboutAppName.Size = new global::System.Drawing.Size(232, 56);
            this.lblAboutAppName.TabIndex = 1;
            this.lblAboutAppName.Text = "Medal Of Honor Heroes™";
            this.lblAboutAppName.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAboutCopyright.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f);
            this.lblAboutCopyright.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
            this.lblAboutCopyright.Location = new global::System.Drawing.Point(64, 120);
            this.lblAboutCopyright.Name = "lblAboutCopyright";
            this.lblAboutCopyright.Size = new global::System.Drawing.Size(232, 23);
            this.lblAboutCopyright.TabIndex = 2;
            this.lblAboutCopyright.Text = "$CMN_CopyRight";
            this.lblAboutCopyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
            this.lblSubtitle.Location = new global::System.Drawing.Point(152, 72);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new global::System.Drawing.Size(168, 23);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "$CMN_DedicatedServer";
            this.lblSubtitle.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
            this.lblModCredit.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f);
            this.lblModCredit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
            this.lblModCredit.Location = new global::System.Drawing.Point(64, 143);
            this.lblModCredit.Name = "lblModCredit";
            this.lblModCredit.Size = new global::System.Drawing.Size(232, 23);
            this.lblModCredit.TabIndex = 4;
            this.lblModCredit.Text = "Modded by Amir. github.com/amir16yp";
            this.lblModCredit.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
            base.ClientSize = new global::System.Drawing.Size(362, 174);
            base.Controls.Add(this.lblModCredit);
            base.Controls.Add(this.lblSubtitle);
            base.Controls.Add(this.lblAboutCopyright);
            base.Controls.Add(this.lblAboutAppName);
            base.Controls.Add(this.pictBoxAbout);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmAbout";
            base.ShowInTaskbar = false;
            this.Text = "$CMN_AboutTitle";
            base.ResumeLayout(false);
        }

        private global::System.Windows.Forms.PictureBox pictBoxAbout;
        private global::System.Windows.Forms.Label lblAboutAppName;
        private global::System.Windows.Forms.Label lblAboutCopyright;
        private global::System.Windows.Forms.Label lblSubtitle;
        private global::System.Windows.Forms.Label lblModCredit;
        private global::System.ComponentModel.Container components = null;
    }
}